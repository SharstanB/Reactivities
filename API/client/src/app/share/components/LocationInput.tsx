import { TextField , Box, Typography, List, ListItemButton, debounce} from "@mui/material";
import axios from "axios";
import { useEffect, useMemo, useState } from "react";
import { FieldValues, Path, useController, UseControllerProps } from "react-hook-form";
import { Control } from 'react-hook-form';

type Props<T extends FieldValues> = {
    control: Control<T>;
    name: Path<T>;
    lable: string;
  } & UseControllerProps<T>
export default function LocationInput<T extends FieldValues>({...props} : Props<T> ) {
    const { field, fieldState } = useController({ ...props });
    const [leading, setLoading] = useState(false);
    const [suggestions, setSuggestions] = useState<LocationIQ[]>([]);
    const [inputValue, setInputValue] = useState(field.value || '');
    const locationUrl = 'https://api.locationiq.com/v1/autocomplete?key=pk.e730f79f302c3b5de402e9eeeb4ba05a&limit=5&dedupe=1&';

   useEffect(() => {
     if(field.value && typeof field.value === "object"){
        setInputValue(field.value.venue || '')
     }else{
        setInputValue(field.value || '')
     }
   },[field.value]);

    const fetchSuggestions = useMemo(()=> debounce(async (query :string) => {
        if (!query || query.length < 3){
            setSuggestions([]);
            return;
        }
        setLoading(true);
        try {
            const res = await axios.get<LocationIQ[]>(`${locationUrl}q=${query}`);
            console.log(res.data);
            setSuggestions(res.data);
        } catch (error) {
            console.log(error);
        }finally{
            setLoading(false);
        }
    }, 500),[locationUrl]);

    const handleChange = async (value: string) => {
        field.onChange(value);
        await fetchSuggestions(value);
    }

   const handleSelect = (location : LocationIQ)=> {
    const city = location.address?.city || location.address?.town || location.address?.village;
    const venue = location.display_name;
    const lat = location.lat;
    const lon = location.lon;

    setInputValue(venue);
    field.onChange({city, venue, lat, lon});
    setSuggestions([]);
   } 
   return (
    <Box>
        <TextField
         {...props}
         value={inputValue}
         onChange={e => handleChange(e.target.value)}
         fullWidth
         variant="outlined"
         error={!!fieldState.error}
         helperText={fieldState.error?.message}
        >
            {leading && <Typography>...Loading </Typography>}
            {suggestions.length > 0 && (
                <List  sx={{border: 1 }}>
                    {suggestions.map(suggestion => (
                        <ListItemButton divider 
                        key={suggestion.place_id}
                        onChange={() => {handleSelect(suggestion)}}>
                           {suggestion.display_name}
                        </ListItemButton>
                    ))}
                </List>
            )  }
        </TextField>
    </Box>
  )
}
