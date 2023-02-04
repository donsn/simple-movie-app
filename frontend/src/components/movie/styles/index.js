import styled from 'styled-components';
import { Link } from 'react-router-dom';

export const SmallMovieContainer = styled(Link)`
    display: flex;
    flex-direction: column;
    justify-content: center;
    text-decoration: none;
    color: #222222; 
    box-shadow: 4px 10px 30px 0px rgba(0,0,0,0.1);
    padding: 1rem;
    border-radius: 0.5rem;
    transition: all 0.5s ease-in-out;
    
    &:hover {
        scale: 1.01;
    }
    `;

export const LargeMovieContainer = styled.div`
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    justify-content: center;
    text-decoration: none;
    color: #222222;
    box-shadow: 4px 10px 30px 0px rgba(0,0,0,0.1);
    padding: 1rem;
    width: 100%;
    border-radius: 0.5rem;
    transition: all 0.5s ease-in-out;
    `;

export const MovieDescriptionContainer = styled.div`
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    justify-content: flex-start;
    max-width: 500px;
`;
export const MovieDescription = styled.p`
    color: #1F2041;
    font-size: 0.9rem;
    text-align: left;
`;

export const MovieTitle = styled.h2`
    color: #1F2041;
    font-size: 1.1rem;
    text-align: left;
`;

export const MoviePosterContainer = styled.div`
    max-width: 300px;
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
    align-items: flex-start;
    justify-content: flex-start;
    width: 100%;
    padding: 0.5rem;
`;