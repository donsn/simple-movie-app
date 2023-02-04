import React from 'react';
import { InputContainer, StyledCountryDropdown, StyledInput, StyledLabel } from './styles';
import CreatableSelect from 'react-select/creatable';


export function InputField({label, ...props}) {

    return (
    <InputContainer>
        <StyledLabel htmlFor={props.id}>{label}</StyledLabel>
        <StyledInput {...props} />
    </InputContainer>
  );
}


export const MultiSelect =  ({options = [], label, ...props}) => 
{
    return (
        <InputContainer>
            <StyledLabel htmlFor={props.id}>{label}</StyledLabel>
            <CreatableSelect isSearchable isClearable isMulti options={options} {...props}/>
        </InputContainer>
    )
}

export const CountryInput = ({label, ...props}) => {
    return (
        <InputContainer>
            <StyledLabel htmlFor={props.id}>{label}</StyledLabel>
            <StyledCountryDropdown onChange={(val)=> props.onChange(val)} value={props.value}/>
        </InputContainer>
    )
}
