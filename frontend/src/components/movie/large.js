import React from 'react';
import { LargeMovieContainer, MovieDescription, MovieDescriptionContainer, MovieDetailsContainer, MoviePosterContainer } from './styles';
import {useAuthentication} from '../../hooks/auth';
import { BASE_URL } from '../../api/base';

/**
 * Renders a large movie view
 * @returns {JSX.Element}
 */
export default function LargeMovieView({movie}) {
  const {authenticated } = useAuthentication();
  return (
    <LargeMovieContainer>
      <MovieDetailsContainer>
        <h1>{movie.name}</h1>
        <MoviePosterContainer large>
          <img src={`${BASE_URL}/images/${movie.photo}`} alt="Movie Poster" />
        </MoviePosterContainer>
        <MovieDescriptionContainer>
          <MovieDescription>
            {movie.description}
          </MovieDescription>
        </MovieDescriptionContainer>
      </MovieDetailsContainer>
      <div>
        <h2>Genre</h2>
        <p>{movie.genres.map(x=> x.name)}</p>
        <h2>Released</h2>
        <p>{new Date(movie.releaseDate).getFullYear()}</p>
        <h2>Rating</h2>
        <p>{movie.rating}</p>
        <h2>Ticket Price</h2>
        <p>{movie.ticketPrice}</p>
        <h2>Country</h2>
        <p>{movie.country}</p>
      </div>
      <div>
        <h2>Comments</h2>
        {authenticated && (
          <button type="button">Comment</button>
        )}
      </div>
    </LargeMovieContainer>
  );
}
