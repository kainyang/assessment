import { ADD_EMPLOYEE, DELETE_EMPLOYEE, EDIT_EMPLOYEE, LOAD_EMPLOYEES } from "./actions";

export const EMPLOYEES = "employees";
const initialState = {
    data: [],
};

export const employeeReducer = function (state = initialState, action) {
    switch (action.type) {
        case LOAD_EMPLOYEES:
            window.localStorage.setItem(EMPLOYEES, JSON.stringify(action.payload));
            return { ...state, data: action.payload };

        case ADD_EMPLOYEE:
            const currentEmployees = JSON.parse(window.localStorage.getItem(EMPLOYEES));
            const updatedEmployees = currentEmployees.concat({
                ...action.payload,
                id: (Math.max.apply(Math, currentEmployees.map((e) => Number(e.id))) + 1).toString(),
            });
            window.localStorage.setItem(EMPLOYEES, JSON.stringify(updatedEmployees));
            return { ...state, data: updatedEmployees };

        case EDIT_EMPLOYEE:
            let currentEmployeesEdit = JSON.parse(window.localStorage.getItem(EMPLOYEES));
            const index = currentEmployeesEdit.findIndex((e) => e.id === action.payload.id);
            let updatedEmployeesEdit = [];
            if (index > -1) {
                currentEmployeesEdit[index] = action.payload;
                updatedEmployeesEdit = currentEmployeesEdit;
            } else {
                updatedEmployeesEdit = currentEmployeesEdit.concat(action.payload);
            }
            window.localStorage.setItem(EMPLOYEES, JSON.stringify(updatedEmployeesEdit));
            return { ...state, data: updatedEmployeesEdit };

        case DELETE_EMPLOYEE:
            let currentEmployeesDelete = JSON.parse(window.localStorage.getItem(EMPLOYEES));
            const updatedEmployeesDelete = [...currentEmployeesDelete.filter((e) => e.id !== action.payload.id)];
            window.localStorage.setItem(EMPLOYEES, JSON.stringify(updatedEmployeesDelete));
            return { ...state, data: updatedEmployeesDelete };

        default:
            return state;
    }
};