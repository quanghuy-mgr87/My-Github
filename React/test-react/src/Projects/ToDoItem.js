import React from 'react'
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import Button from '@mui/material/Button'
import moment from 'moment'

const ToDoItem = ({ name, createDate }) => {
    // const { name, createDate } = item
    return (
        <Grid container spacing={0} className='px-5 mt-2'>
            <Grid item xs={5}>
                {name}
            </Grid>
            <Grid item xs={5}>
                {moment(createDate).format('DD/MM/yyyy')}
            </Grid>
            <Grid item xs={2}>
                <Button size='large' variant='contained'>ADD</Button>
            </Grid>
        </Grid>
    )
}

// const ToDoItem = (props) => {
//     const { name, createDate } = props
//     return (
//         <Grid container spacing={0} className='px-5 mt-2'>
//             <Grid item xs={5}>
//                 {props.name}
//             </Grid>
//             <Grid item xs={5}>
//                 {moment(createDate).format('DD/MM/yyyy')}
//             </Grid>
//             <Grid item xs={2}>
//                 <Button size='large' variant='contained'>ADD</Button>
//             </Grid>
//         </Grid>
//     )
// }

export default ToDoItem
