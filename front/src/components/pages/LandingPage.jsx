import { useState, useContext, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import '../../styles/LandingPage.css';
import { AppStateContext } from "../../context/AppStateProvider"; // Correct import
import Radio from '@mui/material/Radio';
import RadioGroup from '@mui/material/RadioGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import FormControl from '@mui/material/FormControl';
import FormLabel from '@mui/material/FormLabel';
import Slider from '@mui/material/Slider';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import Checkbox from '@mui/material/Checkbox';
import ListItemText from '@mui/material/ListItemText';
import { mapSearch, dateIdeasSearch } from '../../utils/apiCalls';
import { useApiWithoutToken } from '../../hooks';
import SkeletonDance from '../../assets/skeleton-dance.gif'
import CriteriaBox from '../CriteriaBox';
import Switch from '@mui/material/Switch';
import CircularProgress from '@mui/material/CircularProgress';



const LandingPage = () => {
    const { 
        location, setLocation, 
        indoorOutdoor, selectedIndoorOutdoor, setSelectedIndoorOutdoor, 
        duration, selectedDuration, setSelectedDuration, 
        activityLevels, selectedActivityLevels, setSelectedActivityLevels, 
        prices, selectedPrices, setSelectedPrices, 
        ratings, selectedRating, setSelectedRating, 
        mapResponseItems, setMapResponseItems, 
        isLoading, setIsLoading,
        selectedDates, setSelectedDates,
        setMapDateResults,
        setSelectedMapDateResults, 
        setMapResponseDateObjects,
    } = useContext(AppStateContext);

    const [returnedDateIdeas, setReturnedDateIdeas] = useState([]);
    const [showDates, setShowDates] = useState(false);
    const maxNumDates = 5;
    const [maxDatesSelected, setMaxDatesSelected] = useState(false);

    const navigate = useNavigate();
    const pageLocation = useLocation();
    const api = useApiWithoutToken();


    const onSearchButtonClicked = async () => {    
        setSelectedDates([]);    
        setIsLoading(true);
        const ideas = await dateIdeasSearch(
            api, 
            selectedIndoorOutdoor, 
            selectedDuration, 
            selectedActivityLevels, 
            // setIsLoading,
        );
        console.log('ideas: ', ideas);
        setReturnedDateIdeas(ideas);
        setSelectedDates([]);
        setIsLoading(false);
        setShowDates(true);
    }

    const seeDatesButtonClicked = async () => {
        // not calling it asynchonously here so that other page can be navigated to
        setIsLoading(true);
        // mapSearch(
        //     selectedDuration, 
        //     selectedPrices, 
        //     selectedRating, 
        //     selectedActivityLevels, 
        //     selectedIndoorOutdoor, 
        //     location, 
        //     api
        // );

        const selectedDateObjects = returnedDateIdeas.filter((date) => selectedDates.includes(date.name));  
        const response = await mapSearch(
            api,
            selectedDateObjects,
            location,
        );
        setMapResponseItems(response);
        const results = Object.values(response).map(responseItem => responseItem.results).flat();
        setSelectedMapDateResults(results);
        setMapDateResults(results);
        let tempMapResponseDateObjects = {};    
        for(const returnedDateIdea of returnedDateIdeas) {
            if(selectedDates.includes(returnedDateIdea.name)) {
                tempMapResponseDateObjects[returnedDateIdea.name] = returnedDateIdea;
            }
        }
        setMapResponseDateObjects(tempMapResponseDateObjects);
        setIsLoading(false);
        navigate('/map-search');
    }

    const handleDateSelection = (event) => {

        let numDates;

        const date = event.target.value;
        if (selectedDates.includes(date)) {
            setSelectedDates(selectedDates.filter((selectedDate) => selectedDate !== date));
        } else {
            numDates = selectedDates.length+1;
            setSelectedDates([...selectedDates, date]);
        }

        if (numDates+1 > maxNumDates && !selectedDates.includes(event.target.value)) {
            setMaxDatesSelected(true);
        } else {
            if (maxDatesSelected == true) {setMaxDatesSelected(false);}
        }
    }

    // const readyPage = () => {   
    //     setIsLoading(false);
    //     setShowDates(false);
    // }

    useEffect(() => {
        setShowDates(false);
        setIsLoading(false);
    }, [pageLocation]); // Add this useEffect to reset showDates on location change

    const capitalizeFirstLetter = (string) => {
        return string.charAt(0).toUpperCase() + string.slice(1);
    };



    return (
        <div id='LandingPageBody'>         
            <div id='LandingPageMainContent'>
                {!showDates && 
                <>
                    <h1>Find out what to do today!</h1>
                    <div className='hz-center'>
                        <CriteriaBox/>  
                        <div className='v-center'>
                            {/* <p>Setting: {selectedIndoorOutdoor}</p>
                            <p>Duration: {selectedDuration}</p>
                            <p>Activity Level: {selectedActivityLevels}</p>
                            <p>Price: {selectedPrices}</p>
                            <p>Rating: {selectedRating}</p>
                            <p>Location: {location}</p> */}
                        </div>
                    </div>

                    <div className="MapSearchEntrySection">
                            <TextField 
                                label="Enter location" 
                                variant="outlined" 
                                value={location} 
                                onChange={(e) => setLocation(e.target.value)}
                            />
                            <Button 
                                variant="contained" 
                                style={{ backgroundColor: 'var(--tertiary-color)', color: 'white' }} 
                                onClick={() => onSearchButtonClicked()}
                            >
                                Search
                            </Button>
                    </div>
                    {/* <p>or</p>
                    <Button variant="contained" style={{ backgroundColor: '#F69EA3', color: 'white' }}>Free Date Ideas</Button>                 */}
                </>
                }
                {isLoading &&
                    <img src={SkeletonDance} alt="loading symbol" />
                }
                {showDates &&
                    <div id='landing-date-display-selector'>
                        <h1>Choose a date</h1>
                        <p>Choose dates from the list below to see map results for your location</p>
                        <p>*max 5</p>
                        <div id = 'date-display' className='v-center'>
                            <div id='date-display-scrollable-area'>
                                {returnedDateIdeas.map((date, index) => (
                                    <FormControlLabel
                                        key={index}
                                        value={date.name}
                                        control={
                                            <Checkbox
                                                checked={selectedDates.includes(date.name)}
                                                onChange={handleDateSelection}
                                                value={date.name}
                                                disabled={maxDatesSelected && !selectedDates.includes(date.name)}
                                                style={{ color: 'var(--primary-color)' }}
                                            />
                                        }                        
                                        label={capitalizeFirstLetter(date.name)}
                                        sx={{
                                            '& .MuiFormControlLabel-label': {
                                                fontFamily: 'var(--body-font)',
                                                fontWeight: '500',
                                            }
                                        }}
                                    />
                                ))}  
                            </div>
                          
                        </div>
                        <div className='hz-space-btwn'>
                            <Button 
                                variant="contained" 
                                style={{ backgroundColor: 'var(--primary-color)', color: 'white' }} 
                                onClick={() => setShowDates(false)}>Back
                            </Button>
                            <Button 
                                variant="contained" 
                                style={{ backgroundColor: 'var(--secondary-color)', color: 'white' }} 
                                onClick={seeDatesButtonClicked}>See activities
                            </Button>
                        </div>

                    </div>
                }
            </div>
        </div>
    );
};

export default LandingPage;