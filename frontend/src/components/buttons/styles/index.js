import styled from 'styled-components';

export const StyledButton = styled.button`
    padding: 0.5rem 1rem;
    border: none;
    border-radius: 0.25rem;
    font-size: 1rem;
    color: #ffffff;
    background-color: #f50057;
    outline: none;
    transition: all 0.2s ease-in-out;
    cursor: pointer;
    &:hover {
        background-color: #EC0B43;
    }
    &:active {
        background-color: #DB3A34;
    }
`;
