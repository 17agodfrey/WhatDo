import { useState } from 'react';
import PropTypes from 'prop-types';
import caretDown from '../assets/caret-down-solid.svg'; 
import '../styles/FilterButton.css';
import MenuItem from '@mui/material/MenuItem';
import Checkbox from '@mui/material/Checkbox';
import ListItemText from '@mui/material/ListItemText';

const FilterButton = ({ label, variant, listValues, setListValues, children }) => {

    const [showPopup, setShowPopup] = useState(false);

    const togglePopup = () => {
        setShowPopup(!showPopup);
    };

  return (
    <div className="filter-button-container">
    <button onClick={togglePopup} className="filter-button">
        <p>{label}</p>
        <img src={caretDown} alt="caret icon" />
    </button>
    {showPopup && (
        <div className="popup-menu">
            {variant === 'list' ? (
                <div className="list-popup">
                    {listValues.map((value, index) => (
                        <MenuItem key={index} value={value}>
                            <Checkbox />
                            <ListItemText primary={value} />
                        </MenuItem>
                    ))}
                </div>
            ) : (
                <div className="slider-container">
                    {children}
                </div>
            )}
        </div>
    )}
    </div> 
  );
};

FilterButton.propTypes = {
  label: PropTypes.string.isRequired,
  variant: PropTypes.oneOf(['list', 'slider']).isRequired,
  listValues: PropTypes.array.isRequired,
  setListValues: PropTypes.func.isRequired,
  children: PropTypes.node
};

export default FilterButton;



