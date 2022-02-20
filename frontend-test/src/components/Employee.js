import React, { useState, useEffect } from 'react';
import { AgGridReact } from 'ag-grid-react';
import { useDispatch, useSelector } from "react-redux";
import ActionButton from './ActionButton';
import { loadEmployees } from "../employee/actions";
import { getEmployees } from '../employee/service';

import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-alpine.css';

const Employee = () => {
    const { data: rowData } = useSelector((state) => state);
    const dispatch = useDispatch();

    useEffect(() => {
        getEmployees().then(employees => {
            dispatch(loadEmployees(employees));
        });
    }, []);

    const [columnDefs] = useState([
        { headerName: "First Name", field: "firstName" },
        { headerName: "Last Name", field: "lastName" },
        { headerName: "Email", field: "email" },
        { headerName: "Phone No.", field: "number" },
        { headerName: "Gender", field: "gender" },
        { headerName: "Action", cellRenderer: ActionButton },
    ]);

    return (
        <div className="employee">
            <h1>Employee List</h1>
            <div className="ag-theme-alpine" style={{ height: 'calc(100% - 25px)' }}>
                <div style={{ height: 'calc(100% - 50px)', width: '100%' }}>
                    <AgGridReact
                        rowData={rowData}
                        columnDefs={columnDefs}>
                    </AgGridReact>
                </div>
            </div>
        </div>
    );
}

export default Employee;