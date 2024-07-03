import React from 'react';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import '../../styles/LandingPage.css';

const LandingPage = () => {
    return (
        <div id='LandingPageBody'>
            <div id='LandingPageMainContent'>
                <h1>Find your perfect date!</h1>
                <div className="MapSearchEntrySection">
                    <TextField id="outlined-basic" label="Outlined" variant="outlined" />
                    <Button variant="contained" style={{ backgroundColor: '#A1D7F5', color: 'white' }}>Search</Button>
                </div>
                <p>or</p>
                <Button variant="contained" style={{ backgroundColor: '#F69EA3', color: 'white' }}>Free Date Ideas</Button>
            </div>
        </div>
    );
};

export default LandingPage;