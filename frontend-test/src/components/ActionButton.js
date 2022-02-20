import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import { useDispatch } from "react-redux";
import { deleteEmployee } from "../employee/actions";

const ActionButton = (props) => {
    const dispatch = useDispatch();
    
    const onEdit = () => {
        window.location = `/employee/edit/${props.data.id}`;
    };

    const onDelete = () => {
        const confirmResult = window.confirm(`Delete the following employee? \nName: ${props.data.firstName} ${props.data.lastName}`);
        if (confirmResult === true) dispatch(deleteEmployee(props.data));
    };

    return (
        <Stack direction="row" spacing={2}>
            <Button variant="outlined" onClick={() => onEdit()}>
                Edit
            </Button>
            <Button variant="outlined" onClick={() => onDelete()}>
                Delete
            </Button>
        </Stack>
    );
}

export default ActionButton;