import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import { useForm, Controller } from "react-hook-form";
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Radio from '@mui/material/Radio';
import RadioGroup from '@mui/material/RadioGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import { EMAIL_REGEX, SG_PHONE_REGEX } from '../utility/constants';
import { addEmployee, editEmployee, loadEmployees } from "../employee/actions";
import { useParams } from "react-router-dom";
import { getEmployees } from '../employee/service';

const CreateEditEmployee = () => {
    const { control, register, formState: { errors }, handleSubmit, setValue } = useForm({
        defaultValues: {
            firstName: '',
            lastName: '',
            emailAddress: '',
            phoneNumber: '',
            gender: 'female'
        }
    });

    const { id } = useParams();
    const formType = window.location.pathname === "/employee/add" ? "ADD" : "EDIT";
    const dispatch = useDispatch();

    const onSubmit = (data) => {
        console.log(data);
        if (formType === "ADD") dispatch(addEmployee({ ...data }));
        if (formType === "EDIT") dispatch(editEmployee({ ...data, id: id }));
    }

    useEffect(() => {
        getEmployees().then(employees => {
            dispatch(loadEmployees(employees));

            if (formType === "EDIT" && employees.length > 0) {
                const employee = employees[id - 1];
                const fields = ['firstName', 'lastName', 'email', 'number', 'gender'];

                fields.forEach(field => setValue(field, employee[field]));
            }
        });
    }, []);

    return (
        <div className="create-employee">
            <form onSubmit={handleSubmit(onSubmit)}>
                <div>
                    <Controller
                        name="firstName"
                        control={control}
                        render={({ field }) =>
                            <TextField
                                {...field}
                                {...register("firstName", { required: true, minLength: 6, maxLength: 10 })}
                                placeholder="Enter first name" />
                        }
                    />
                    <div className='field-error'>
                        {errors.firstName?.type === 'required' && "First name is required"}
                        {errors.firstName?.type === 'minLength' && "Minimum 6 characters"}
                        {errors.firstName?.type === 'maxLength' && "Maximum 10 characters"}
                    </div>
                </div>
                <div>
                    <Controller
                        name="lastName"
                        control={control}
                        render={({ field }) =>
                            <TextField
                                {...field}
                                {...register("lastName", { required: true, minLength: 6, maxLength: 10 })}
                                placeholder="Enter last name" />
                        }

                    />
                    <div className='field-error'>
                        {errors.lastName?.type === 'required' && "Last name is required"}
                        {errors.lastName?.type === 'minLength' && "Minimum 6 characters"}
                        {errors.lastName?.type === 'maxLength' && "Maximum 10 characters"}
                    </div>
                </div>
                <div>
                    <Controller
                        name="email"
                        control={control}
                        render={({ field }) =>
                            <TextField
                                {...field}
                                {...register("email", { required: true, pattern: EMAIL_REGEX })}
                                placeholder="Enter email address" />
                        }
                    />
                    <div className='field-error'>
                        {errors.email?.type === 'required' && "Email is required"}
                        {errors.email?.type === 'pattern' && "Invalid email address"}
                    </div>
                </div>
                <div>
                    <Controller
                        name="number"
                        control={control}
                        render={({ field }) =>
                            <TextField
                                {...field}
                                {...register("number", { required: true, pattern: SG_PHONE_REGEX })}
                                type="tel"
                                placeholder="Enter phone number" />
                        }
                    />
                    <div className='field-error'>
                        {errors.number?.type === 'required' && "Phone number is required"}
                        {errors.number?.type === 'pattern' && "Invalid Singapore phone number"}
                    </div>
                </div>
                <div>
                    <Controller
                        name="gender"
                        control={control}
                        render={({ field }) =>
                            <RadioGroup
                                {...field}
                            >
                                <FormControlLabel value="female" control={<Radio />} label="Female" />
                                <FormControlLabel value="male" control={<Radio />} label="Male" />
                            </RadioGroup>}
                    />
                </div>
                <Button variant="outlined" type="submit">
                    Submit
                </Button>
            </form>
        </div>
    );
}

export default CreateEditEmployee;