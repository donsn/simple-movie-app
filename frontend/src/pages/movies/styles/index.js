import styled from 'styled-components';

export const FlexContainer = styled.div`
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    min-height: 100vh;
    width: 100%;
    flex-wrap: wrap;
    padding: 1rem;
    gap: 1.5rem;
`;

export const Title = styled.h1`
    font-size: 2rem;
    font-weight: 700;
    color: #222222;
    text-align: center;
    `;

export const Form = styled.form`
    display: flex;
    flex-direction: column;
    gap: 1rem;
    width: 100%;
    max-width: 500px;
    padding: 1rem;
    border: 1px solid #e0e0e0;
    border-radius: 0.25rem;
    background-color: #ffffff;
`;
