import React, { useEffect, useState } from 'react'
import { AgGridReact } from 'ag-grid-react'; 
import "ag-grid-community/styles/ag-grid.css"; 
import "ag-grid-community/styles/ag-theme-quartz.css";   
import { Link } from "react-router-dom";
import NoOfEmployeeRenderer from "../components/cafe/noOfEmployeeRenderer.jsx";
import LogoRenderer from "../components/cafe/logoRenderer.jsx"; 
import CafeButtonActionRenderer from "../components/cafe/cafeButtonActionRenderer.jsx"
import Modal from 'react-modal';
import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle } from '@mui/material';
import ConfirmDialog from "../components/common/ConfirmDialog.jsx";
import CustomTextBox from "../components/common/CustomTextBox.jsx";
import { makeStyles } from '@mui/styles';

const useStyles = makeStyles((theme) => ({
    textField: {
        width: '100%', // Set the width to 100%
    },
    dialogField: {
        width: '450', // Set the width to 100%
    },
}));

const Cafe = () => {

    const [cafes, setCafes] = useState();
    const pagination = true;
    const paginationPageSize = 10;
    const paginationPageSizeSelector = [10, 20, 30,40];
    const [modalIsOpen, setModalIsOpen] = useState(false);
    const [openConfirmation, setOpenConfirmation] = useState(false); 
    const [currentRowData, setCurrentRowData] = useState(null);
    const classes = useStyles();
    const [logo, setLogo] = useState(null);

    // Column Definitions: Defines the columns to be displayed.
    const [colDefs, setColDefs] = useState([
        { field: "logo", width: 100, cellRenderer: LogoRenderer },
        { field: "name", filter: true, width: 250, },
        { field: "description", filter: true, width: 350, },
        {
            headerName: 'No Of Employees', 
            width: 200,
            field: "noOfemployees",
            cellRenderer: NoOfEmployeeRenderer,
        },
        { field: "location", filter: true, width: 300, },
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
        setCurrentRowData({ name: '', description: '', location: ''});
        setModalIsOpen(true);
    };

    const closeModal = () => {
        setModalIsOpen(false);
        setCurrentRowData(null);
    };

    const handleFormSubmit = (event) => {
        event.preventDefault();
        updateCafeRecord();
        closeModal();
    };

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setCurrentRowData({ ...currentRowData, [name]: value });
    };

    const handleFileChange = (event) => {
        setLogo(event.target.files[0]);
    };

    const handleUpload = () => {
        if (logo) {
            const reader = new FileReader();
            reader.readAsArrayBuffer(logo);

            reader.onloadend = async () => {
                const byteArray = new Uint8Array(reader.result);
                const fileContent = Array.from(byteArray);
                setCurrentRowData({ ...currentRowData, ['logo']: fileContent });
                console.log(fileContent)
                console.log('File uploaded')
                console.log(currentRowData)
            }
        }
        else {
            alert("select a logo for cafe.")
        }
    };


    const handleConfirm = async () => {
        try {

            const response = await fetch('cafes\\' + (currentRowData.id == undefined ? '' : currentRowData.id), {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(currentRowData),
            });

            const result = await response.json();
            loadCafesData();
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
    }, []);

    return (
        <div className="ag-theme-quartz" style={{ height: 500 }}  >
            <Button onClick={openAddModal} color="primary" autoFocus>
                Add New Cafe
            </Button>
            {cafes === undefined ? <p><em>Loading...</em></p> : 
                
                <AgGridReact
                pagination={pagination}
                paginationPageSize={paginationPageSize}
                rowData={cafes}
                columnDefs={colDefs}
            /> }

            <Dialog
                open={modalIsOpen}
                onClose={closeModal}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description" className={classes.dialogField}
            >
                <DialogTitle id="alert-dialog-title">{"Edit Cafe"}</DialogTitle>

                {currentRowData && (
                 <div> <DialogContent>

                        <label>
                            Name:
                            <CustomTextBox currentRowDataValue={currentRowData.name}
                                label="name" minLength={6} maxLength={10} 
                                name="name"
                                value={currentRowData.name}
                                onTextChange={handleInputChange}
                            />
                        </label>
                        <br />
                        <label>
                            Description:
                            <CustomTextBox maxLength={256} currentRowDataValue={currentRowData.description }
                                label="description"
                                name="description"
                                value={currentRowData.description}
                                onTextChange={handleInputChange}
                            />
                        </label>
                        <br />
                        <label>
                            Location:
                            <CustomTextBox currentRowDataValue={currentRowData.location}
                                maxLength={256} label="location"
                                name="location"
                                value={currentRowData.location}
                                onTextChange={handleInputChange}
                            />
                        </label>
                        <br />
                        <label>
                            Logo:
                            <div>
                                <input type="file" onChange={handleFileChange} />
                            </div>
                        </label>
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
                message="Are you sure you want to delete this cafe?"
            />
        </div>
    )

    async function loadCafesData() {
        const response = await fetch('cafes');
        const data = await response.json();
        setCafes(data);
    }

    async function deleteRow(props) {
        setCurrentRowData(props.data)
        setOpenConfirmation(true);
    };

    async function updateCafeRecord() { 
       
        try {
            if (logo) {
                const reader = new FileReader();
                reader.readAsArrayBuffer(logo);

                reader.onloadend = async () => {
                    const byteArray = new Uint8Array(reader.result);
                    const fileContent = btoa(String.fromCharCode.apply(null, byteArray));

                    const payload = {
                        id: currentRowData.id,
                        name: currentRowData.name,
                        description: currentRowData.description,
                        location: currentRowData.location,
                        logo: fileContent
                    };
                    console.log(payload)
                    console.log(JSON.stringify(payload))
                    const response = await fetch('cafes\\' + (payload.id == undefined ? '' : payload.id), {
                        method: currentRowData.id == undefined ? 'POST' : 'PUT',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(payload),
                    });

                    const result = await response.json();
                    loadCafesData();
                }
            }
            else {
                alert("upload a logo for cafe.")
            }
          
        } catch (error) {
            console.error('Error:', error);
        }
    }
}


export default Cafe