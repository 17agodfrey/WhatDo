import React, { useState } from 'react';
import { Select, MenuItem, Checkbox, ListItemText, FormControl, OutlinedInput } from '@mui/material';
import { styled } from '@mui/material/styles';
import PropTypes from 'prop-types';
import CaretDown from '../assets/caret-down-solid.svg';
import '../styles/FilterButton.css';

const ChipButton = styled('div')(({ theme }) => ({
  display: 'flex',
  alignItems: 'center',
  backgroundColor: theme.palette.primary.main,
  color: theme.palette.primary.contrastText,
  borderRadius: theme.shape.borderRadius,
  padding: theme.spacing(0.5, 1),
  cursor: 'pointer',
  '& img': {
    marginLeft: theme.spacing(1),
  },
}));

const FilterButton = ({ label, listValues, setListValues }) => {
  const [anchorEl, setAnchorEl] = useState(null);

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const handleChange = (event) => {
    const {
      target: { value },
    } = event;
    setListValues(
      typeof value === 'string' ? value.split(',') : value,
    );
    handleClose();
  };

  return (
    <FormControl sx={{ m: 1, width: 300 }}>
      <ChipButton onClick={handleClick}>
        <p>{label}</p>
        <img id='caret' src={CaretDown} alt="caret icon" />
      </ChipButton>
      <Select
        multiple
        open={Boolean(anchorEl)}
        onClose={handleClose}
        onOpen={handleClick}
        value={listValues}
        onChange={handleChange}
        input={<OutlinedInput />}
        renderValue={() => null} // Prevent showing selected values in the chip
        MenuProps={{
          anchorEl: anchorEl,
          getContentAnchorEl: null,
          PaperProps: {
            style: {
              maxHeight: 48 * 4.5 + 8,
              width: 250,
            },
          },
        }}
      >
        {listValues.map((value, index) => (
          <MenuItem key={index} value={value}>
            <Checkbox checked={listValues.indexOf(value) > -1} />
            <ListItemText primary={value} />
          </MenuItem>
        ))}
      </Select>
    </FormControl>
  );
};

FilterButton.propTypes = {
  label: PropTypes.string.isRequired,
  listValues: PropTypes.array.isRequired,
  setListValues: PropTypes.func.isRequired,
};

export default FilterButton;
