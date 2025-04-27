import {
  Box,
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  TextField,
  Typography,
} from "@mui/material";
import { SelectChangeEvent } from '@mui/material/Select';
import { FormEvent, useState } from "react";
import { useActivities } from "../../../lib/hooks/useActivities";
import {useCities} from "../../../lib/hooks/useCities";
import {useCategories} from "../../../lib/hooks/useCategories";
import { Link, useNavigate, useParams } from "react-router";
import { FormatDate } from "../../../lib/util/util";

export default function ActivityForm() {
  const navigation = useNavigate();
  const {id} = useParams();
  const {citieslist} = useCities();
  const {categorieslist} = useCategories();
  const [selectedCity, setCity] = useState('');
  const [selectedCategory, setCategory] = useState('');
  const { updateActivity, createActivity , activityDetail ,isLoadingActivity } = useActivities(id);
  const handleSubmit = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const formDate = new FormData(event.currentTarget);
    const data: { [key: string]: FormDataEntryValue } = {};
    formDate.forEach((value, key) => {
      data[key] = value;
    });
    data.cityId =  selectedCity.length === 0 ? activityDetail?.cityId : selectedCity;
    data.categoryId =  selectedCategory.length === 0 ? activityDetail?.categoryId : selectedCategory;
    if (activityDetail?.id) {
      data.id = activityDetail.id;
      console.log(data);
      updateActivity.mutate(data as unknown as Activity);
      navigation(`/activities/${data.id}`);
    } else {
      createActivity.mutate(data as unknown as Activity);
      navigation('/activities');
    }
   
  };
  const handleCategoryChange = (event: SelectChangeEvent) =>{
      setCategory(event.target.value as string);
  }

  const handleCityChange = (event: SelectChangeEvent) =>{
    setCity(event.target.value as string);
}
  if(isLoadingActivity) return <Typography> isLoading...</Typography>
  return (
    <Paper sx={{ borderRadius: 3, padding: 3 }}>
      <Typography gutterBottom variant="h5" color="warning">
       {activityDetail ? 'Edit Activity': 'Create Activity'} 
      </Typography>
      <Box
        component="form"
        onSubmit={handleSubmit}
        sx={{ display: "flex", flexDirection: "column", gap: 3 }}
      >
        <TextField
          name="title"
          label="Title"
          defaultValue={activityDetail?.title}
        ></TextField>

        <FormControl fullWidth>
          <InputLabel id="demo-simple-select-label">Category</InputLabel>
          <Select
            labelId="demo-simple-select-label"
            id="demo-simple-select"
            value={
              selectedCategory.length === 0 ? activityDetail?.categoryId : selectedCategory
            }
            label="City"
            onChange={handleCategoryChange}
          >
            {categorieslist?.map((category) => (
              <MenuItem key={category.id}  value={category.id}>{category.name}</MenuItem>
            ))}
          </Select>
        </FormControl>
        <TextField
          name="date"
          label="Date"
          type="date"
          defaultValue={
            activityDetail?.date
              ? FormatDate(activityDetail.date)
              : FormatDate(new Date())
          }
        ></TextField>
        <TextField
          name="description"
          label="Description"
          multiline
          rows={3}
          defaultValue={activityDetail?.description}
        ></TextField>
        <FormControl fullWidth>
          <InputLabel id="demo-simple-select-label">City</InputLabel>
          <Select
            labelId="demo-simple-select-label"
            id="demo-simple-select"
            value={
              selectedCity.length === 0 ? activityDetail?.cityId : selectedCity
            }
            label="City"
            onChange={handleCityChange}
          >
            {citieslist?.map((city) => (
              <MenuItem key={city.id} value={city.id}>{city.name}</MenuItem>
            ))}
          </Select>
        </FormControl>

        <TextField
          name="venue"
          label="Venue"
          defaultValue={activityDetail?.venue}
        ></TextField>
        <Box sx={{ display: "flex", justifyContent: "end", gap: 3, mt: 4 }}>
          <Button component={Link}  to={'/activities'} color="inherit">
            Cancle
          </Button>
          <Button color="success" variant="contained" type="submit"
           disabled={updateActivity.isPending || createActivity.isPending}
          >
            Submit
          </Button>
        </Box>
      </Box>
    </Paper>
  );
}
