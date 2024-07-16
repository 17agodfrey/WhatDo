import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import '../../styles/LandingPage.css';

const LandingPage = () => {
    const navigate = useNavigate();
    const [location, setLocation] = useState('');

    const onSearchButtonClicked = () => {
        if (location.trim() !== '') {
            navigate(`/map-search?location=${encodeURIComponent(location)}`);
        }    
    }


    return (
        <div id='LandingPageBody'>
            <div id='LandingPageMainContent'>
                <h1>Find your perfect date!</h1>
                <div className="MapSearchEntrySection">
                        <TextField 
                            id="outlined-basic" 
                            label="Enter location" 
                            variant="outlined" 
                            value={location} 
                            onChange={(e) => setLocation(e.target.value)}
                        />
                        <Button 
                            variant="contained" 
                            style={{ backgroundColor: '#A1D7F5', color: 'white' }} 
                            onClick={() => onSearchButtonClicked()}
                        >
                            Search
                        </Button>
                </div>
                <p>or</p>
                <Button variant="contained" style={{ backgroundColor: '#F69EA3', color: 'white' }}>Free Date Ideas</Button>
            </div>
        </div>
    );
};

export default LandingPage;