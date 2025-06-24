import React, { useContext } from 'react';
import { FormControl, RadioGroup, FormControlLabel, Radio, Checkbox, Slider } from '@mui/material';
import { AppStateContext } from '../context/AppStateProvider';

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
            style={{ 
                color: 'var(--primary-color)', 
                '& .MuiFormControlLabel-label': {
                    fontFamily: 'var(--body-font)',
                    fontWeight: '500',
                },
            }}
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

    const handleRatingChange = (event) => {
        setSelectedRating(event.target.value);
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
                                style={{ color: 'var(--primary-color)'}}
                            />
                        }                        
                        label={value}
                        sx={{
                            '& .MuiFormControlLabel-label': {
                                fontFamily: 'var(--body-font)',
                                fontWeight: '500',
                            }
                        }}
                    />
                ))}            
            </>
        );
    };

    return (
        <div id='criteria-box'>
            <h3 className='criteria-box-selector-label body-text'>Setting</h3>
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
                                control={<Radio style={{ color: 'var(--primary-color)' }} />}
                                label={value}
                                sx={{
                                    '& .MuiFormControlLabel-label': {
                                        fontFamily: 'var(--body-font)',
                                        fontWeight: '500',
                                    }
                                }}
                        />
                        ))}
                    </RadioGroup>
                </FormControl>
            </div>
            <h3 className='criteria-box-selector-label  body-text'>Duration</h3>
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
            <h3 className='criteria-box-selector-label body-text'>Activity Level</h3>
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
            <h3 className='criteria-box-selector-label body-text'>Price</h3>
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
            <h3 className='criteria-box-selector-label body-text'>Rating</h3>
            <div className='criteria-box-selector'>
                {/* <FormControl style={{display: 'flex', flexDirection: 'row'}}>
                    <CheckBoxSelector 
                        label='Rating' 
                        possibleValues={ratings.map(value => value.toString()).filter(value => Number.isInteger(Number(value)))}
                        selectedValues={selectedRating} 
                        setSelectedValues={setSelectedRating}
                    />
                </FormControl> */}
                <FormControl
                >
                    <RadioGroup
                        row
                        aria-labelledby="criteria-box-setting-radio-buttons-group-label"
                        name="row-radio-buttons-group"
                        value={selectedRating}
                        onChange={handleRatingChange} // Update state on change
                    >
                        {ratings.map((value) => (
                            <FormControlLabel
                                key={value}
                                value={value}
                                control={<Radio style={{ color: 'var(--primary-color)'}} />}
                                label={value + '+'}  
                                sx={{
                                    '& .MuiFormControlLabel-label': {
                                        fontFamily: 'var(--body-font)',
                                        fontWeight: '500',
                                    }
                                }}
                            />
                        ))}
                    </RadioGroup>
                </FormControl>
            </div>
        </div>
    );
}

export default CriteriaBox;