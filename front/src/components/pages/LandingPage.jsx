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
import { mapSearch, dateIdeas } from '../../utils/apiCalls';
import { useApiWithoutToken } from '../../hooks';
import SkeletonDance from '../../assets/skeleton-dance.gif'



const DurationSlider = ({ selectedDuration, handleDurationSliderChange, valuetext, duration, marks }) => {
    return (
        <Slider
            getAriaLabel={() => 'Duration'}
            value={selectedDuration}
            onChange={handleDurationSliderChange}
            valueLabelDisplay="off"
            getAriaValueText={valuetext}
            min={duration[0]}
            max={duration[duration.length - 1]}
            marks={marks}
            step={0.5}
        />
    );
};

const CriteriaBox = () => {
    const { 
        indoorOutdoor, selectedIndoorOutdoor, setSelectedIndoorOutdoor, 
        duration, selectedDuration, setSelectedDuration, 
        activityLevels, selectedActivityLevels, setSelectedActivityLevels, 
        prices, selectedPrices, setSelectedPrices, 
        ratings, selectedRating, setSelectedRating 
    } = useContext(AppStateContext);
    
    const handleSettingChange = (event) => {
        setSelectedIndoorOutdoor(event.target.value);
    };

    const handleDurationSliderChange = (event, newValue) => {
        setSelectedDuration(newValue);
    };
    
    function valuetext(value) {
    return `${value}`;
    }    

    const marks = duration.filter(value => Number.isInteger(value)).map((value) => ({
    value,          
    label: String(value) 
    }));
    
    const CheckBoxSelector = ({label, possibleValues, selectedValues, setSelectedValues}) => {
        const handleChange = (event) => {
            const { target: { value } } = event;
            const newSelectedValues = selectedValues.includes(value)
                ? selectedValues.filter((selectedValue) => selectedValue !== value)
                : [...selectedValues, value];
            setSelectedValues(newSelectedValues);
        };

        return (
            <>
                {possibleValues.map((value) => (
                    <FormControlLabel
                        key={value}
                        value={selectedValues}
                        control={
                            <Checkbox
                                checked={selectedValues.includes(value)}
                                onChange={handleChange}
                                value={value}
                            />
                        }                        
                        label={value}
                    />
                ))}            
            </>
        );
    };

    return (
        <div id='criteria-box'>
            <h3 className='criteria-box-selector-label'>Setting</h3>
            <div className='criteria-box-selector'>
                <FormControl>
                    <RadioGroup
                        row
                        aria-labelledby="criteria-box-setting-radio-buttons-group-label"
                        name="row-radio-buttons-group"
                        value={selectedIndoorOutdoor}
                        onChange={handleSettingChange} // Update state on change
                    >
                        {indoorOutdoor.map((value) => (
                            <FormControlLabel
                                key={value}
                                value={value}
                                control={<Radio />}
                                label={value}
                            />
                        ))}
                    </RadioGroup>
                </FormControl>
            </div>
            <h3 className='criteria-box-selector-label'>Duration</h3>
            <div className='criteria-box-selector'>
                <FormControl style={{ width: '80%' }}>
                    <DurationSlider
                        selectedDuration={selectedDuration}
                        handleDurationSliderChange={handleDurationSliderChange}
                        valuetext={valuetext}
                        duration={duration}
                        marks={marks}
                    />
                </FormControl>
            </div>
            <h3 className='criteria-box-selector-label'>Activity Level</h3>
            <div className='criteria-box-selector'>
                <FormControl style={{display: 'flex', flexDirection: 'row'}}>
                    <CheckBoxSelector 
                        label='Activity Level' 
                        possibleValues={activityLevels}
                        selectedValues={selectedActivityLevels} 
                        setSelectedValues={setSelectedActivityLevels}
                    />
                </FormControl>
            </div>
            <h3 className='criteria-box-selector-label'>Price</h3>
            <div className='criteria-box-selector'>
                <FormControl style={{display: 'flex', flexDirection: 'row'}}>
                    <CheckBoxSelector 
                        label='Price' 
                        possibleValues={prices}
                        selectedValues={selectedPrices} 
                        setSelectedValues={setSelectedPrices}
                    />
                </FormControl>
            </div>
            <h3 className='criteria-box-selector-label'>Rating</h3>
            <div className='criteria-box-selector'>
                <FormControl style={{display: 'flex', flexDirection: 'row'}}>
                    <CheckBoxSelector 
                        label='Rating' 
                        possibleValues={ratings.map(value => value.toString()).filter(value => Number.isInteger(Number(value)))}
                        selectedValues={selectedRating} 
                        setSelectedValues={setSelectedRating}
                    />
                </FormControl>
            </div>
        </div>
    );
}

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
        selectedDates, setSelectedDates
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
        const ideas = await dateIdeas(
            api, 
            selectedIndoorOutdoor, 
            selectedDuration, 
            selectedActivityLevels, 
            // setIsLoading,
        );
        console.log('ideas: ', ideas);
        setReturnedDateIdeas(ideas);
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


    return (
        <div id='LandingPageBody'>
            <div id='LandingPageMainContent'>
                {!showDates && 
                <>
                    <h1>Find your perfect date!</h1>
                    <div className='hz-center'>
                        <CriteriaBox/>  
                        <div className='v-center'>
                            <p>Setting: {selectedIndoorOutdoor}</p>
                            <p>Duration: {selectedDuration}</p>
                            <p>Activity Level: {selectedActivityLevels}</p>
                            <p>Price: {selectedPrices}</p>
                            <p>Rating: {selectedRating}</p>
                            <p>Location: {location}</p>
                        </div>
                    </div>

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
                </>
                }
                {isLoading &&
                    <img src={SkeletonDance} alt="loading symbol" />
                }
                {showDates &&
                    <div id='landing-date-display-selector'>
                        <h1>Choose a date</h1>
                        <p>Choose a date from the list below to see more details</p>
                        <p>*max 5 dates</p>
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
                                            />
                                        }                        
                                        label={date.name}
                                    />
                                ))}  
                            </div>
                          
                        </div>
                        <div className='hz-space-btwn'>
                            <Button 
                                variant="contained" 
                                style={{ backgroundColor: '#F69EA3', color: 'white' }} 
                                onClick={() => setShowDates(false)}>Back
                            </Button>
                            <Button 
                                variant="contained" 
                                style={{ backgroundColor: '#A1D7F5', color: 'white' }} 
                                onClick={seeDatesButtonClicked}>See dates
                            </Button>
                        </div>

                    </div>
                }
            </div>
        </div>
    );
};

export default LandingPage;