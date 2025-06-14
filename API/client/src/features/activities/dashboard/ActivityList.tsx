import { Grid, Typography } from '@mui/material'
import { useActivities } from '../../../lib/hooks/useActivities';
import ActivityCard from './ActivityCard';


export default function  ActivityList() {
  const {activityResult, isPending} = useActivities();
 
  console.log(activityResult);
  if(!activityResult || isPending  ) 
   return (<Typography> Is Loading ... </Typography>)

  return (
     <Grid sx={{ display: 'flex', flexDirection: 'column', gap :3}}   >
      {activityResult?.map((activity: Activity) => (
        <ActivityCard key={activity.id}  activity={activity} 
        />
      ))}
    </Grid>
  )
}
