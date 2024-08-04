import React, { useEffect, useState } from 'react'
import { AgGridReact } from 'ag-grid-react';
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";  
import { useSearchParams } from 'react-router-dom';
import Modal from 'react-modal';
import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle } from '@mui/material';
import ConfirmDialog from "../components/common/ConfirmDialog.jsx";
import CustomTextBox from "../components/common/CustomTextBox.jsx";
import { Radio, RadioGroup, FormControlLabel, FormControl, FormHelperText, FormLabel } from '@mui/material';
import { Select, MenuItem, InputLabel } from '@mui/material';
import { makeStyles } from '@mui/styles';
 

const useStyles = makeStyles((theme) => ({
    textField: {
        width: '100%', // Set the width to 100%
    },
    dialogField: {
        width: '450', // Set the width to 100%
    },
}));

const Employee = () => {
    const [employees, setEmployees] = useState();
    const [searchParams, setSearchParams] = useSearchParams();
    const pagination = true;
    const paginationPageSize = 10;
    const paginationPageSizeSelector = [10, 20, 30, 40];
    const [modalIsOpen, setModalIsOpen] = useState(false);
    const [openConfirmation, setOpenConfirmation] = useState(false);
    const [currentRowData, setCurrentRowData] = useState(null);
    const [cafes, setCafes] = useState([]);
    const classes = useStyles();
    const [cafeId, setCafeId] = useState([]);

    const [formErrors, setFormErrors] = useState({
        name_error: '',
        email_address: '',
        phone_number: '',
        gender: ''
    });

    // Column Definitions: Defines the columns to be displayed.
    const [colDefs, setColDefs] = useState([
        { field: "name" },
        { field: "email_address" },
        { field: "phone_number" },
        { field: "gender" },
        { field: "days_worked" },
        { field: "cafe" },
        {
            headerName: 'Actions',
            width: 200,
            cellRenderer: (params) => (
                <div>  <button onClick={() => deleteRow(params)}>Delete</button>
                    <button onClick={() => openEditModal(params.data)}>Edit</button> </div>
            ),
        },
    ]);

    const openEditModal = (data) => {
        setCurrentRowData(data);
        setModalIsOpen(true);
    };


    const openAddModal = (data) => {
        setCurrentRowData({ name: '', description: '', location: '',cafe: '' });
        setModalIsOpen(true);
    };

    const closeModal = () => {
        setModalIsOpen(false);
        setCurrentRowData(null);
    };

    const handleFormSubmit = (event) => {
        event.preventDefault();

        const errors = validate();
        if (Object.keys(errors).length === 0) {
            updateEmployeeRecord();
            closeModal();
        }
        else {
            setFormErrors(errors);
        }
    };

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setCurrentRowData({ ...currentRowData, [name]: value });
    };

    const handleGenderChange = (event) => {
        setCurrentRowData({ ...currentRowData, ['gender']: event.target.value });
    };

    const handleCafesChange = (event) => {
        setCurrentRowData({ ...currentRowData, ['cafe']: event.target.value });
    }; 

    const validate = () => {
        let errors = {};
        if (!currentRowData.name) {
            errors.name_error = 'Name is required';
        }
        else if (currentRowData.name.length > 10 || currentRowData.name.length < 6) {
           errors.name_error = 'Names length should be minimum 6 and maximum 10';
        }
        if (!currentRowData.email_address) {
            errors.email_address = 'Email is required';
        } else if (!/\S+@\S+\.\S+/.test(currentRowData.email_address)) {
            errors.email_address = 'Email address is invalid';
        }
        if (!currentRowData.gender) {
            errors.gender = 'Gender is required';

            if (!currentRowData.phone_number) {
                errors.phone_number = 'Phone is required';
            }
            else if ((currentRowData.phone_number[0] != '9' && currentRowData.phone_number[0] != '8') || currentRowData.phone_number.length != 8) {
                errors.phone_number = 'Phone is invalid';
            }
        }

        return errors;
    }

        const handleConfirm = async () => {
            try {

                const response = await fetch('employees\\' + (currentRowData.id == undefined ? '' : currentRowData.id), {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(currentRowData),
                });

                const result = await response.json();
                loadEmployeesData();
                setOpenConfirmation(false);
            } catch (error) {
                console.error('Error:', error); handleConfirmClose
            }
        };

        const handleConfirmClose = () => {
            setOpenConfirmation(false);
        };

    useEffect(() => {
            loadCafesData();
            loadEmployeesData();
        }, []);

        return (
            <div className="ag-theme-quartz" style={{ height: 500 }} >
                <Button onClick={openAddModal} color="primary" autoFocus>
                    Add New Cafe
                </Button>
                {employees === undefined ? <p><em>Loading...</em></p> : <AgGridReact
                    pagination={pagination}
                    paginationPageSize={paginationPageSize} 
                    //paginationPageSizeSelector={paginationPageSizeSelector}
                    rowData={employees}
                    columnDefs={colDefs}
                />}

                <Dialog
                    open={modalIsOpen}
                    onClose={closeModal}
                    aria-labelledby="alert-dialog-title"
                    aria-describedby="alert-dialog-description" className={classes.dialogField}
                >
                    <DialogTitle id="alert-dialog-title" className={classes.dialogField}>{"Add / Edit Employee"}</DialogTitle >

                    {currentRowData && cafes && (
                        <div> <DialogContent className={classes.dialogField}>

                            <label>
                                Name:
                                <CustomTextBox currentRowDataValue={currentRowData.name}
                                    label="name" minLength={6} maxLength={10}
                                    name="name"
                                    value={currentRowData.name}
                                    onTextChange={handleInputChange}
                                    errorMessage={formErrors.name_error}
                                    className={classes.textField}
                                    margin="normal"
                                />
                            </label>
                            <br />
                            <label>
                                Email:
                                <CustomTextBox maxLength={256} currentRowDataValue={currentRowData.email_address} isEmailField='true'
                                    label="email_address"
                                    name="email_address"
                                    value={currentRowData.email_address}
                                    onTextChange={handleInputChange}
                                    errorMessage={formErrors.email_address}
                                    className={classes.textField}
                                    margin="normal"
                                />
                            </label>
                            <br />
                            <label>
                                Phone:
                                <CustomTextBox currentRowDataValue={currentRowData.phone_number} isPhoneFielld='true'
                                    maxLength={256} label="phone"
                                    name="phone_number"
                                    value={currentRowData.phone_number}
                                    onTextChange={handleInputChange}
                                    errorMessage={formErrors.phone_number}
                                    className={classes.textField}
                                    margin="normal"
                                />
                            </label>
                            <br />
                            <FormControl component="fieldset">
                                <FormLabel component="legend">Gender</FormLabel>
                                <RadioGroup
                                    aria-label="options"
                                    name="options"
                                    value={currentRowData.gender}
                                    onChange={handleGenderChange}
                                    error={Boolean(formErrors.gender)}
                                    helperText={formErrors.gender}
                                    className={classes.textField}
                                >
                                    <FormControlLabel value="Male" control={<Radio />} label="Male" />
                                    <FormControlLabel value="Female" control={<Radio />} label="Female" />
                                </RadioGroup>
                                {formErrors.gender && <FormHelperText className="Mui-error">{formErrors.gender}</FormHelperText>}

                            </FormControl>
                            <br />
                            <FormControl fullWidth variant="outlined">
                                <FormLabel component="legend">Select Cafes</FormLabel>
                                {/*<InputLabel id="select-label">Select Cafes</InputLabel>*/}
                                <Select
                                    labelId="select-label"
                                    value={currentRowData.cafe}
                                    onChange={handleCafesChange}
                                    label="Select Cafes"
                                >
                                    {cafes.map((option) => (
                                        <MenuItem key={option.id} value={option.name}>
                                            {option.name}
                                        </MenuItem>
                                    ))}
                                </Select>
                            </FormControl>
                            <br />

                        </DialogContent>

                            <DialogActions>
                                <Button onClick={closeModal} color="primary">
                                    Cancel
                                </Button>
                                <Button onClick={handleFormSubmit} color="primary" autoFocus>
                                    Save
                                </Button>
                            </DialogActions></div>
                    )}
                </Dialog>
                <ConfirmDialog
                    open={openConfirmation}
                    onClose={handleConfirmClose}
                    onConfirm={handleConfirm}
                    title="Confirm Action"
                    message="Are you sure you want to delete this Employee?"
                />
            </div>
        )

        async function loadEmployeesData() {
            let url = ''
            if (searchParams.get('cafe') == '') {
                url = 'employees'
                setCafeId('');
            }
            else {
                url = 'employees/' + searchParams.get('cafe')
                setCafeId(searchParams.get('cafe'))
            }
            setCurrentRowData({ ...currentRowData, ['cafe']: cafeId });
            const response = await fetch(url);
            const data = await response.json();
            setEmployees(data);
        }

        async function deleteRow(props) {
            setCurrentRowData(props.data)
            setOpenConfirmation(true);
        };


        async function loadCafesData() {
            const response = await fetch('cafes');
            const data = await response.json();
            setCafes(data);
            if (cafeId != '') {
               let selectedCafe = data.filter(function (i, n) {
                    return i.id == cafeId;
               });

                if (selectedCafe.length > 0) {
                    setCurrentRowData({ ...currentRowData, ['cafe']: selectedCafe[0].name });
                }
            }
        }


        async function updateEmployeeRecord() {

            try {

                const response = await fetch('employees\\' + (currentRowData.id == undefined ? '' : currentRowData.id), {
                    method: currentRowData.id == undefined ? 'POST' : 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(currentRowData),
                });

                const result = await response.json();
                loadEmployeesData();
            } catch (error) {
                console.error('Error:', error);
            }
        }
    }

export default Employee