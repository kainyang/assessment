import { EMPLOYEES } from "./reducer";

export async function getEmployees() {
    const apiURL = "https://6164f6e709a29d0017c88ed9.mockapi.io/fetest/employees"
    let employees = [];

    if (window.localStorage.getItem(EMPLOYEES)) {
        employees = JSON.parse(window.localStorage.getItem(EMPLOYEES));
    } else {
        await fetch(apiURL)
            .then(res => res.json())
            .then(employeeList => employees = employeeList);
    }

    return employees;
}