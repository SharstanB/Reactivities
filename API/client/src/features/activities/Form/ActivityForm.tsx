import {
  Box,
  Button,
  Paper,
  TextField,
  Typography,
} from "@mui/material";
import { useEffect } from "react";
import { useActivities } from "../../../lib/hooks/useActivities";
import { useCities } from "../../../lib/hooks/useCities";
import { useCategories } from "../../../lib/hooks/useCategories";
import { Link, useParams } from "react-router";
import { FormatDate } from "../../../lib/util/util";
import { useForm } from "react-hook-form";
import {
  activitySchema,
  ActivitySchema,
} from "../../../lib/schemas/activitySchema";
import { zodResolver } from "@hookform/resolvers/zod";
import TextInput from "../../../app/share/components/TextInput";
import SelectInput from "../../../app/share/components/SelectInput";

export default function ActivityForm() {
  const { register, reset, handleSubmit, control } = useForm<ActivitySchema>({
    mode: "onTouched",
    resolver: zodResolver(activitySchema),
  });
  const { id } = useParams();
  const { updateActivity, createActivity, activityDetail, isLoadingActivity } =
    useActivities(id);
  const { citieslist } = useCities();
  const { categorieslist } = useCategories();
  // const [selectedCity, setCity] = useState("");
  // const [selectedCategory, setCategory] = useState("");

  useEffect(() => {
    // if (activityDetail) reset(activityDetail);
  }, [activityDetail, reset]);
  const onSubmit = (data: ActivitySchema) => {
    console.log(data);
  };
  // const handleSubmit = (event: FormEvent<HTMLFormElement>) => {
  //   event.preventDefault();
  //   const formDate = new FormData(event.currentTarget);
  //   const data: { [key: string]: FormDataEntryValue } = {};
  //   formDate.forEach((value, key) => {
  //     data[key] = value;
  //   });
  //   data.cityId =  selectedCity.length === 0 ? activityDetail?.cityId : selectedCity;
  //   data.categoryId =  selectedCategory.length === 0 ? activityDetail?.categoryId : selectedCategory;
  //   if (activityDetail?.id) {
  //     data.id = activityDetail.id;
  //     console.log(data);
  //     updateActivity.mutate(data as unknown as Activity);
  //     navigation(`/activities/${data.id}`);
  //   } else {
  //     createActivity.mutate(data as unknown as Activity);
  //     navigation('/activities');
  //   }

  // };

  // const handleCategoryChange = (event: SelectChangeEvent) => {
  //   setCategory(event.target.value);
  // };

  // const handleCityChange = (event: SelectChangeEvent) => {
  //   setCity(event.target.value as string);
  // };

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
          name='category' 
          control={control}  >
        </SelectInput>
        {/*
        <Select
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          value={
            selectedCategory.length === 0
              ? activityDetail?.categoryId
              : selectedCategory
          }
          label="Category"
          onChange={handleCategoryChange}
        >
          {categorieslist?.map((category) => (
            <MenuItem key={category.id} value={category.id}>
              {category.name}
            </MenuItem>
          ))}
        </Select> */}

        <TextField
          {...register("date")}
          label="Date"
          type="date"
          // error={!!errors.date}
          // helperText= {errors.date?.message}
          defaultValue={
            activityDetail?.date
              ? FormatDate(activityDetail.date)
              : FormatDate(new Date())
          }
        ></TextField>

        <TextInput
          label='Description'
          multiline
          rows={3}
          control ={control}
          name='description'
        ></TextInput>

        <SelectInput label='City' 
          items={citieslist} 
          name='city' 
          control={control}  >
        </SelectInput>
        {/* <FormControl fullWidth>
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
              <MenuItem key={city.id} value={city.id}>
                {city.name}
              </MenuItem>
            ))}
          </Select>
        </FormControl> */}

        <TextInput
          label= "Venue"
          control = {control}
          name="venue"
        />

        <Box sx={{ display: "flex", justifyContent: "end", gap: 3, mt: 4 }}>
          <Button component={Link} to={"/activities"} color="inherit">
            Cancle
          </Button>
          <Button
            color="success"
            variant="contained"
            type="submit"
            disabled={updateActivity.isPending || createActivity.isPending}
          >
            Submit
          </Button>
        </Box>
      </Box>
    </Paper>
  );
}
