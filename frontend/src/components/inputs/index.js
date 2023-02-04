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

/**
 * Transforms select options to react-select options
 * @param {*} options 
 * @returns 
 */
export const transformOptions = (options) => {
    if (options) {
        return options.map(option => {
            return {
                label: option.name,
                value: option.id
            }
        })        
    }

    return [];
}

/**
 * Transforms the output of react-select to the format that the backend expects
 * @param {*} options 
 * @returns 
 */
export const transformOutput = (options) => {
    if (options) {
        return options.map(option => {
            return {
                name: option.label,
                id: option.value
            }
        })
    }

    return [];
}


export const CountryInput = ({label, ...props}) => {
    return (
        <InputContainer>
            <StyledLabel htmlFor={props.id}>{label}</StyledLabel>
            <StyledCountryDropdown onChange={(val)=> props.onChange(val)} value={props.value}/>
        </InputContainer>
    )
}
