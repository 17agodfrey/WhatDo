import { useState, useContext } from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import Checkbox from '@mui/material/Checkbox';
import FormControlLabel from '@mui/material/FormControlLabel';
import {AppStateContext} from "../context/AppStateProvider";


const DialogButton = ({text,}) => {
    const {
        mapResponseItems, 
        selectedDates, setSelectedDates,
    } = useContext(AppStateContext);

    const [open, setOpen] = useState(false);

    const handleDialogChange = () => {
        setOpen(!open);
    }

    const handleChange = (event) => {
        const date = event.target.value;
        if (selectedDates.includes(date)) {
            setSelectedDates(selectedDates.filter((selectedDate) => selectedDate !== date));
        } else {
            setSelectedDates([...selectedDates, date]);
        }
    }


    return (
        <>
            <Button 
                variant="outlined" 
                onClick={handleDialogChange}
                sx={{
                    minWidth: 'fit-content', 
                    backgroundColor: '#A1D7F5',
                    fontWeight: 'inherit',
                    color: 'currentColor',
                    borderRadius: '16px',
                }}
            >{text}
            </Button>
            <Dialog
            open={open}
            onClose={handleDialogChange}
            aria-labelledby="alert-dialog-title"
            aria-describedby="alert-dialog-description"
            >
            <div id='map-search-dialog-content'>
            <DialogTitle id="alert-dialog-title">
                {"Date types used: "}
            </DialogTitle>
            <DialogContent 
                // sx={{'&& .MuiDialogContent-root': {display: 'flex', flexDirection: 'column', alignItems: 'center'}}}
            >
                {/* <DialogContentText id="alert-dialog-description">
                Let Google help apps determine location. This means sending anonymous
                location data to Google, even when no apps are running.
                </DialogContentText> */}
                <div className='v-center'> 
                    {Object.values(mapResponseItems).map((mapResponseItem, index1) => (
                            <FormControlLabel
                                key={mapResponseItem.date.name}
                                value={mapResponseItem.date.name}
                                control={
                                    <Checkbox
                                        checked={selectedDates.includes(mapResponseItem.date.name)}
                                        onChange={handleChange}
                                        value={mapResponseItem.date.name}
                                    />
                                }                        
                                label={mapResponseItem.date.name}
                            />
                        ))}  
                </div>
               
            </DialogContent>
            {/* <DialogActions>
                <Button onClick={handleDialogChange}>Disagree</Button>
                <Button onClick={handleDialogChange} autoFocus>
                Agree
                </Button>
            </DialogActions> */}
            </div>
            </Dialog>          
      </>
    );
}

export default DialogButton;