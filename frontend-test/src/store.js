import { createStore } from "redux";
import { employeeReducer } from "./employee/reducer";

export const store = createStore(
    employeeReducer
);