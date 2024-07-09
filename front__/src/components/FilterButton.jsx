import { useState } from 'react';
import PropTypes from 'prop-types';
import '../styles/FilterButton.css';
import '../styles/index.css';
import MenuItem from '@mui/material/MenuItem';
import Checkbox from '@mui/material/Checkbox';
import ListItemText from '@mui/material/ListItemText';
import FormControl from '@mui/material/FormControl';
import InputLabel from '@mui/material/InputLabel';
import Select from '@mui/material/Select';
import OutlinedInput from '@mui/material/OutlinedInput';
import InputBase from '@mui/material/InputBase';
import { styled } from '@mui/material/styles';
import Slider from '@mui/material/Slider';


const fontFamily = [
  '-apple-system',
  'BlinkMacSystemFont',
  '"Segoe UI"',
  'Roboto',
  '"Helvetica Neue"',
  'Arial',
  'sans-serif',
  '"Apple Color Emoji"',
  '"Segoe UI Emoji"',
  '"Segoe UI Symbol"',
].join(',');

const MenuProps = {
  PaperProps: {
    style: {
      // maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      // height: 'fit-content',
      // width: 'fit-content',
    },
  },
  disableAutoFocusItem: true,
};

function valuetext(value) {
  return `${value}`;
}

const calculateLabelWidth = (label) => {
  const canvas = document.createElement('canvas');
  const context = canvas.getContext('2d');
  context.font = `400 14px ${fontFamily}`;
  const width = context.measureText(label).width;
  return width + 60;
};

const FilterButton = ({ label, variant, possibleValues, selectedValues, setSelectedValues }) => {
  const [value, setValue] = useState([20, 37]);
  const labelWidth = calculateLabelWidth(label);

  const handleChange = (event) => {
    const { target: { value } } = event;
    setSelectedValues(typeof value === 'string' ? value.split(',') : value);
  };

  const handleSliderChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <div className='filter-button'>
        <FormControl size='small' sx={{minWidth: `${labelWidth}px`}}>
        <InputLabel 
              id="demo-customized-select-label" 
              shrink={false}
        >
          {label}
        </InputLabel>
        {variant === 'list' ? (
            <Select
              autoWidth
              multiple
              value={selectedValues}
              renderValue={()=> ''}
              onChange={handleChange}
              MenuProps={MenuProps}
            >
            {possibleValues.map((value) => (
                <MenuItem key={value} value={value}>
                    <Checkbox  checked={selectedValues.indexOf(value) > -1}/>
                    <ListItemText primary={value} />
                </MenuItem>
            ))}
            </Select>
        ) : (
            <Select
              fullWidth={true}
              MenuProps={MenuProps}
            >
              <MenuItem sx={{width: '200px'}}>
                <Slider
                  getAriaLabel={() => 'Temperature range'}
                  value={value}
                  onChange={handleSliderChange}
                  valueLabelDisplay="off"
                  getAriaValueText={valuetext}
                />            
              </MenuItem>
            </Select>
         )} 
        </FormControl>
    </div>
  );
};

FilterButton.propTypes = {
  label: PropTypes.string.isRequired,
  variant: PropTypes.oneOf(['list', 'slider']).isRequired,
  possibleValues: PropTypes.array.isRequired,
  selectedValues: PropTypes.array.isRequired,
  setSelectedValues: PropTypes.func.isRequired,
  children: PropTypes.node
};

export default FilterButton;
