import React from 'react'
import TextField from '@mui/material/TextField'
import AdapterDateFns from '@mui/lab/AdapterDateFns';
import LocalizationProvider from '@mui/lab/LocalizationProvider';
import DesktopDatePicker from '@mui/lab/DesktopDatePicker';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import Button from '@mui/material/Button'
import ToDoItem from './ToDoItem';
import moment from 'moment'


const ToDoApp = () => {
    const [name, setName] = React.useState('')
    const [createDate, setCreateDate] = React.useState(new Date())
    const [toDoList, setToDoList] = React.useState([])


    const handleChange = (newValue) => {
        setCreateDate(newValue);
    };
    const AddItem = () => {
        let toDoItem = { name, createDate }
        console.log(toDoItem)
        setToDoList(oldArray => [...oldArray, toDoItem]);
        console.log(toDoList)
    }
    // React.useEffect(() => {
    //     console.log(toDoList)
    // }, [toDoList])


    return (
        <div className='pt-5'>
            <Box sx={{ flexGrow: 1 }}>
                <Grid container spacing={0} className='px-5'>
                    <Grid item xs={5}>
                        <TextField id="standard-basic" label="Name" variant="outlined" value={name} onChange={(e) => setName(e.target.value)} />

                    </Grid>
                    <Grid item xs={5}>
                        <LocalizationProvider dateAdapter={AdapterDateFns}>
                            <DesktopDatePicker
                                label="Date desktop"
                                inputFormat="dd/MM/yyyy"
                                value={createDate}
                                onChange={handleChange}
                                renderInput={(params) => <TextField {...params} />}
                            />
                        </LocalizationProvider>
                    </Grid>
                    <Grid item xs={2}>
                        <Button size='large' variant='contained' onClick={AddItem}>ADD</Button>
                    </Grid>
                </Grid>
            </Box>
            <Box className='mt-5'>
                {toDoList.map((item, index) => {
                    // const { name, createDate } = toDoItem
                    return (
                        <ToDoItem key={index} {...item}></ToDoItem>
                        // <ToDoItem key={index} props={item}></ToDoItem>
                        // <Grid key={index} container spacing={0} className='px-5 mt-2'>
                        //     <Grid item xs={5}>
                        //         {toDoItem.name}
                        //     </Grid>
                        //     <Grid item xs={5}>
                        //         {moment(toDoItem.createDate).format("DD/MM/yyyy")}
                        //     </Grid>
                        //     <Grid item xs={2}>
                        //         <Button size='large' variant='contained'>ADD</Button>
                        //     </Grid>
                        // </Grid>
                    )
                })}
            </Box>
        </div>
    )
}

export default ToDoApp
