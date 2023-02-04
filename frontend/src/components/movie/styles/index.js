import styled from 'styled-components';
import { Link } from 'react-router-dom';

export const SmallMovieContainer = styled(Link)`
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    text-decoration: none;
    color: #222222; 
    box-shadow: 0 0px 10px rgba(0, 0, 0, 0.1);
    padding: 1rem;
    border-radius: 0.5rem;
    transition: all 0.2s ease-in-out;

    &:hover {
        scale: 1.01;
        box-shadow: 0 0px 10px rgba(0, 0, 0, 0.2);
    }
`;

export const MovieTitle = styled.h2`
    color: #1F2041;
    font-size: 1.5rem;
`;

export const MoviePosterContainer = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    align-items: center;
    border-radius: 0.5rem;
    overflow: hidden;

    img {
        width: 100%;
        object-fit: cover;
    }
`;

export const MovieDetailsContainer = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: flex-start;
`;