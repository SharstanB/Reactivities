import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import {  Button, Container, LinearProgress } from '@mui/material';
import { Group } from '@mui/icons-material';
import MenuItemLink from '../share/components/MenuItemLink';
import { useStore } from '../../lib/hooks/useStore';
import { Observer } from 'mobx-react-lite';


export default function NavBar() {
  const {uiStore} = useStore();
  return (
    // Box like div inside material ui and it allows us to add styling
    <Box sx={{ flexGrow: 1 }} > 
         <AppBar position="static" 
         sx={{backgroundImage: 'linear-gradient(153deg, #182a73 0%, #218aae 69%, #20a7ac 89%)'}}>
         <Container maxWidth='xl' >
         <Toolbar sx={{display: 'flex' ,justifyContent:'space-between'}} >
          <Box>
            <MenuItemLink to='/'>
              <Group fontSize='large'/>
              <Typography variant='h5' fontWeight= 'bold'  sx={{textTransform:'none'}}>Reactivities</Typography>
            </MenuItemLink>
          </Box>
           <Box  sx={{display:'flex', justifyContent:'space-around'}}>
             <MenuItemLink to='/activities'  >
               Activities
             </MenuItemLink>
             <MenuItemLink  to='/createActivity'>
               Create Activity
             </MenuItemLink>
             <MenuItemLink to='/counter'>
               Contact
             </MenuItemLink>
           </Box>
            <Button onClick={() => console.log('')} size='medium' variant='contained' color='warning'> Create Activity</Button>
        </Toolbar>
         </Container>
         <Observer>
            {() => uiStore.isLoading ? (<LinearProgress  color='secondary' />) : null}
         </Observer>
       
      </AppBar>
    </Box>
  );
}
