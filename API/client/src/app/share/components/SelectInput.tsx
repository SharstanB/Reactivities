import { UseControlledProps } from '@mui/utils/useControlled';
import { FieldValues, useController } from 'react-hook-form'
import { FormControl, FormHelperText, InputLabel, MenuItem } from '@mui/material';
import Select, { SelectProps } from '@mui/material/Select';
// import {SelectInputProps } from '@mui/mat erial/Select/SelectInput';

type Props<T extends FieldValues> = {
   items : BasicListObject[] | undefined;
   lable: string
} & UseControlledProps<T> & Partial<SelectProps>

export default function SelectInput<T extends FieldValues>(props: Props<T>) {
    const {field, fieldState} = useController({...props}); 
    console.log(fieldState.error?.message)
    return (
    <FormControl  fullWidth  error={!!fieldState.error}>
      <InputLabel>{props.label}</InputLabel>
      <Select value={field.value || ''}
         label={props.label}
         onChange={field.onChange}
         error={!!fieldState.error}>
         {props.items?.map(item  => (
            <MenuItem key={item.id} value={item.id}>
                {item.name}
            </MenuItem>
         ))}

      </Select>
      <FormHelperText>{fieldState.error?.message}</FormHelperText>
    </FormControl>
  )
}
