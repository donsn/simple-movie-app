import styled from 'styled-components';
import { CountryDropdown} from 'react-country-region-selector';


export const InputContainer = styled.div`
    display: flex;
    flex-direction: column;
    margin-bottom: 1rem;
`;

export const StyledInput = styled.input`
    padding: 0.5rem;
    border: 1px solid #e0e0e0;
    border-radius: 0.25rem;
    font-size: 1rem;
    color: #222222;
    background-color: #ffffff;
    outline: none;
    transition: all 0.2s ease-in-out;
  
`;

export const StyledLabel = styled.label`
    color: #222222;
    font-size: 0.85rem;

`;

export const StyledCountryDropdown = styled(CountryDropdown)`
    padding: 0.5rem;
    border: 1px solid #e0e0e0;
    border-radius: 0.25rem;
    font-size: 1rem;
    color: #222222;
    background-color: #ffffff;
    outline: none;
    transition: all 0.2s ease-in-out;
`;