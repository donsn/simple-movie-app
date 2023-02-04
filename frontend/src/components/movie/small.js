import React from 'react';
import { slugify } from '../../utilities/slugify';
import Rating from '../rating';
import { SmallMovieContainer, MovieTitle, MoviePosterContainer, MovieDetailsContainer } from './styles';

export default function SmallMovieView({ movie }) {
  return (
    <SmallMovieContainer to={`/movies/${slugify('Spider Man - Far From Home')}`}>
      <MovieTitle>Spider Man - Far From Home</MovieTitle>
      <MoviePosterContainer>
        <img src="https://via.placeholder.com/300x450" alt="Movie Poster" />
      </MoviePosterContainer>
      <MovieDetailsContainer>
        <p>Released: {new Date().getFullYear()}</p>
        <Rating rating={3} />
      </MovieDetailsContainer>
    </SmallMovieContainer>
  );
}
