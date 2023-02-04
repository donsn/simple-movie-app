import React from 'react';
import { BASE_URL } from '../../api/base';
import Rating from '../rating';
import { SmallMovieContainer, MovieTitle, MoviePosterContainer, MovieDetailsContainer } from './styles';

export default function SmallMovieView({ movie }) {
  return (
    <SmallMovieContainer to={`/movies/${movie.slug}`}>
      <MovieTitle>{movie.name}</MovieTitle>
      <MoviePosterContainer>
        <img src={`${BASE_URL}/images/${movie.photo}`} alt="Movie Poster" />
      </MoviePosterContainer>
      <MovieDetailsContainer>
        <p>Released: {new Date(movie.releaseDate).getFullYear()}</p>
        <Rating rating={movie.rating} />
      </MovieDetailsContainer>
    </SmallMovieContainer>
  );
}
