import React, { useState } from 'react';
import TextField from '@mui/material/TextField';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';

const CustomTextBox = ({ label, minLength, maxLength, onTextChange, currentRowDataValue, isEmailField, isPhoneFielld, errorMessage, className }) => {
    const [value, setValue] = useState(currentRowDataValue);
    const [error, setError] = useState(errorMessage);

    const validateEmail = (email) => {
        const re = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
        return re.test(String(email).toLowerCase());
    };
     
    const handleChange = (event) => {
        const newValue = event.target.value;
        let errorMsg= '';

        if (newValue.length < minLength) {
            errorMsg = `Minimum length is ${minLength}`;
        } else if (newValue.length > maxLength) {
            errorMsg = `Maximum length is ${maxLength}`;
        }

        if (isEmailField == 'true') {
            if (validateEmail(event.target.value) == false) {
                errorMsg = 'Invalid email address';
            }
        }

        if (isPhoneFielld == 'true') {
            if ((event.target.value[0] != '9' && event.target.value[0] != '8') || event.target.value.length != 8) {
                errorMsg = 'Invalid phone no';
            }
        }

        onTextChange(event);
        setValue(newValue);
        setError(errorMsg);
    };

    return (
        <Box fullWidth>
            <TextField
                name={label}
                label={label}
                value={currentRowDataValue}
                onChange={handleChange}
                error={Boolean(error) ? Boolean(error) : Boolean(errorMessage)}
                helperText={error ? error : errorMessage}
                margin="normal"
                variant="outlined"
                className={className }
            />
           
        </Box>
    );
};

export default CustomTextBox;
