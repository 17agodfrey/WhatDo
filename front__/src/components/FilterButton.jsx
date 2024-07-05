import { useState } from 'react';
import PropTypes from 'prop-types';
import '../styles/FilterButton.css';
import MenuItem from '@mui/material/MenuItem';
import Checkbox from '@mui/material/Checkbox';
import ListItemText from '@mui/material/ListItemText';
import FormControl from '@mui/material/FormControl';
import InputLabel from '@mui/material/InputLabel';
import Select from '@mui/material/Select';
import OutlinedInput from '@mui/material/OutlinedInput';
import InputBase from '@mui/material/InputBase';
import { styled } from '@mui/material/styles';



const BootstrapInput = styled(InputBase)(({ theme }) => ({
  // 'label + &': {
  //   marginTop: theme.spacing(3),
  // },
  // 'MuiInputBase-root': {
  //   width: '6rem',
  '& .MuiInputBase-input': {
    position: 'relative',
    backgroundColor: "#A1D7F5",
    border: '1px solid #ced4da',
    borderRadius: 16, // Increase the border radius value for more rounded corners
    fontSize: 16,
    fontWeight: 'bold',
    padding: '.5rem .5rem .5rem 1rem',
    // transition: theme.transitions.create(['border-color', 'box-shadow']),
    // Use the system font instead of the default Roboto font.
    fontFamily: [
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
    ].join(','),
    '&:focus': {
      borderColor: '#80bdff',
      boxShadow: '0 0 0 0.2rem rgba(0,123,255,.25)',
      borderRadius: 16, // Increase the border radius value for more rounded corners
    },
  },
  '.MuiSelect-icon': {
    color: '#F69EA3',
    fontSize: '2rem',
  },
}));


const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      width: 250,
    },
  },
  disableAutoFocusItem: true,
};

const FilterButton = ({ label, variant, possibleValues, selectedValues, setSelectedValues, children }) => {
  const handleChange = (event) => {
    const { target: { value } } = event;
    setSelectedValues(typeof value === 'string' ? value.split(',') : value);
  };

  return (
        <FormControl>
        {/* {variant === 'list' ? ( */}
            <Select
            multiple
            value={selectedValues}
            onChange={handleChange}
            displayEmpty={true}
            renderValue= {() => label}
            input={<BootstrapInput />}
            MenuProps={MenuProps}
            >
            {possibleValues.map((value) => (
                <MenuItem key={value} value={value}>
                    <Checkbox  checked={selectedValues.indexOf(value) > -1}/>
                    <ListItemText primary={value} />
                </MenuItem>
            ))}
            </Select>
        {/* ) : (
            <div className="slider-container">
            {children}
            </div>
        )} */}
        </FormControl>
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
