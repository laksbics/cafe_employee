import React, { useEffect, useState, EditingForm, Button } from 'react'
import { Dialog, DialogActions, DialogContent, DialogTitle } from '@mui/material'
import { useDispatch } from "react-redux";

export default (props) => {
    
    const { id } = props.data.id;
    const [open, setOpen] = useState(false);
    const [memberPayload, setMemberPayload] = useState(props.data.id);
    const dispatch = useDispatch();
    const onClose = () => setOpen(false);
    const onSave = () => {
        // dispatch(memberAction.update(id, memberPayload));
        onClose();
    }
    const deleteRow = (props) => {
        alert(props.data.id);
    };

    return (
        <>
            <button onClick={() => deleteRow(props)}>Delete</button>
        </>
    );
} 