import { Grid, Typography } from '@mui/material'
import { useActivities } from '../../../lib/hooks/useActivities';
import ActivityCard from './ActivityCard';


export default function  ActivityList() {
  const {activities, isPending} = useActivities();
 
  if(!activities || isPending ) 
  <Typography> Is Loading ... </Typography>

  return (
    <Grid sx={{ display: 'flex', flexDirection: 'column', gap :3}}   >
      {activities?.map((activity) => (
        <ActivityCard key={activity.id}  activity={activity} 
        />
      ))}
    </Grid>
  )
}
