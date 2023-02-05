import styled from 'styled-components';

export const Container = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
    padding: 1rem;
    margin: 1rem 0.5rem;
`;

export const CommentContainer = styled.div`
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    justify-content: flex-start;
    width: 100%;
    padding: 1rem;

    h5{
        color: #1F2041;
        font-size: 1rem;
    }
    p {
        color: #1F2041;
        font-size: 0.9rem;
        text-align: left;
    }
`;
