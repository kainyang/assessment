import React from 'react';
import { Link } from "react-router-dom";
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import ViewListIcon from '@mui/icons-material/ViewList';
import AddIcon from '@mui/icons-material/Add';

const Navbar = () => {
    const [value, setValue] = React.useState(0);

    const handleChange = (event, newValue) => {
        setValue(newValue);
    };

    return (
        <div>
            <h1>Frontend Test</h1>
            <Tabs value={value} onChange={handleChange} centered>
                <Tab icon={<ViewListIcon />} label="View Employees" component={Link} to={"/employee/list"} />
                <Tab icon={<AddIcon />} label="Add/ Edit Employee" component={Link} to={"/employee/add"} />
            </Tabs>
        </div>
    );
}

export default Navbar;