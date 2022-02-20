export const LOAD_EMPLOYEES = "LOAD_EMPLOYEES";
export const ADD_EMPLOYEE = "ADD_EMPLOYEE";
export const EDIT_EMPLOYEE = "EDIT_EMPLOYEE";
export const DELETE_EMPLOYEE = "DELETE_EMPLOYEE";

export const loadEmployees = (employees) => ({
    type: LOAD_EMPLOYEES,
    payload: employees,
});

export const addEmployee = (employee) => ({
    type: ADD_EMPLOYEE,
    payload: employee,
});

export const editEmployee = (employee) => ({
    type: EDIT_EMPLOYEE,
    payload: employee,
});

export const deleteEmployee = (employee) => ({
    type: DELETE_EMPLOYEE,
    payload: employee,
});