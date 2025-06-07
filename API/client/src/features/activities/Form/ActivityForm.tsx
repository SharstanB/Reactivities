import {
  Box,
  Button,
  Paper,
  Typography,
} from "@mui/material";
import { useEffect } from "react";
import { useActivities } from "../../../lib/hooks/useActivities";
// import { useCities } from "../../../lib/hooks/useCities";
import { useCategories } from "../../../lib/hooks/useCategories";
import { Link, useParams } from "react-router";
import { useForm } from "react-hook-form";
import {
  activitySchema,
  ActivitySchema,
} from "../../../lib/schemas/activitySchema";
import { zodResolver } from "@hookform/resolvers/zod";
import TextInput from "../../../app/share/components/TextInput";
import SelectInput from "../../../app/share/components/SelectInput";
import DataInput from "../../../app/share/components/DataInput";
import LocationInput from "../../../app/share/components/LocationInput";
import { router } from "../../../app/router/routes";

export default function ActivityForm() {
  const {reset,handleSubmit, control } = useForm<ActivitySchema>({
    mode: "onTouched",
    resolver: zodResolver(activitySchema),
  });
  const { id } = useParams();
  const { updateActivity, createActivity, activityDetail, isLoadingActivity } =
    useActivities(id);
  // const { citieslist } = useCities();
  const { categorieslist } = useCategories();

  // You receive new activity details from an API and want to auto-fill the form:
  useEffect(() => {
    if (activityDetail) reset(activityDetail);
  }, [activityDetail, reset]);
  const onSubmit = (data: ActivitySchema) => {
       console.log(data);
      createActivity.mutate(data as unknown as Activity);
      router.navigate('/activities');
  };

  if (isLoadingActivity) return <Typography> isLoading...</Typography>;
  return (
    <Paper sx={{ borderRadius: 3, padding: 3 }}>
      <Typography gutterBottom variant="h5" color="warning">
        {activityDetail ? "Edit Activity" : "Create Activity"}
      </Typography>

      <Box
        component="form"
        onSubmit={handleSubmit(onSubmit)}
        sx={{ display: "flex", flexDirection: "column", gap: 3 }}
      >
        <TextInput 
          label='Title'
          control= {control}
          name="title"></TextInput>
        <SelectInput label='Category' 
          items={categorieslist} 
          name='categoryId' 
          control={control}  >
        </SelectInput>
         <DataInput
          control={control}
          name='date'
          label='Date'
         />
        <TextInput
          label='Description'
          multiline
          rows={3}
          control ={control}
          name='description'
        ></TextInput>
        {/* <SelectInput label='City' 
          items={citieslist} 
          name='cityId' 
          control={control}  >
        </SelectInput> */}
        {/* <TextInput
          label= "Venue"
          control = {control}
          name="venue"
        /> */}
        <LocationInput 
        control={control} 
        lable='Enter the location' 
        name='location'></LocationInput>
        
        <Box sx={{ display: "flex", justifyContent: "end", gap: 3, mt: 4 }}>
          <Button component={Link} to={"/activities"} color="inherit">
            Cancle
          </Button>
          <Button
            color="success"
            variant="contained"
            type="submit"
            disabled={updateActivity.isPending || createActivity.isPending}>
            Submit
          </Button>
        </Box>
      </Box>
    </Paper>
  );
}
