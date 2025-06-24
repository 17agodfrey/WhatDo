import { useState, useContext, useEffect } from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import Checkbox from '@mui/material/Checkbox';
import FormControlLabel from '@mui/material/FormControlLabel';
import {AppStateContext} from "../context/AppStateProvider";


const DialogButton = ({text, content, title=null, onClose=null, isOpen=null, setIsOpen=null, buttonStyles }) => {
    const {
        mapResponseItems, 
        selectedDates, setSelectedDates,
    } = useContext(AppStateContext);

    const [open, setOpen] = useState(isOpen !== null ? isOpen : false);

    const toggleDialogOpen = () => {
        setOpen(!open);
        if(open && onClose){
            onClose();
        }

        if(setIsOpen){
            setIsOpen(!open);
        }
    }

    useEffect(() => {
        if(isOpen){
            setOpen(isOpen);
        } else {
            setOpen(false);
            if(onClose){
                onClose();
            }
        }
    }, [isOpen])


    return (
        <>
            <Button 
                variant="outlined" 
                onClick={toggleDialogOpen}
                sx={{
                    ...buttonStyles,
                    minWidth: 'fit-content', 
                    fontWeight: '500',
                    fontSize: '16px',
                    fontFamily: 'var(--body-font)',
                    color: 'currentColor',
                    borderRadius: '16px',
                    textTransform: 'none', 

                }}
            >{text}
            </Button>
            <Dialog
            open={open}
            onClose={toggleDialogOpen}
            aria-labelledby="alert-dialog-title"
            aria-describedby="alert-dialog-description"
            >
            {title && <DialogTitle id="alert-dialog-title">{title}</DialogTitle>}
            <DialogContent 
                // sx={{'&& .MuiDialogContent-root': {display: 'flex', flexDirection: 'column', alignItems: 'center'}}}
                sx={{maxHeight: 'fit-content'}}
            >
                {/* <DialogContentText id="alert-dialog-description">
                Let Google help apps determine location. This means sending anonymous
                location data to Google, even when no apps are running.
                </DialogContentText> */}
                {/* <div className='v-center'>  */}
                    {content}
                {/* </div> */}
            </DialogContent>
            {/* <DialogActions>
                <Button onClick={handleDialogChange}>Disagree</Button>
                <Button onClick={handleDialogChange} autoFocus>
                Agree
                </Button>
            </DialogActions> */}
            </Dialog>          
      </>
    );
}

export default DialogButton;