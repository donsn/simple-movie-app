import React from 'react';
import { LargeMovieContainer, MovieDescription, MovieDescriptionContainer, MovieDetailsContainer, MoviePosterContainer, GridContainer, MetaDataContainer } from './styles';
import { BASE_URL } from '../../api/base';
import Comments from '../comment';

/**
 * Renders a large movie view
 * @returns {JSX.Element}
 */
export default function LargeMovieView({movie}) {
  return (
    <LargeMovieContainer>
      <GridContainer>
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
      <MetaDataContainer>
        <h2>Genre</h2>
        <p>{movie.genres.map(x=> x.name).join(', ')}</p>
        <h2>Released</h2>
        <p>{new Date(movie.releaseDate).getFullYear()}</p>
        <h2>Rating</h2>
        <p>{movie.rating}</p>
        <h2>Ticket Price</h2>
        <p>{movie.ticketPrice}</p>
        <h2>Country</h2>
        <p>{movie.country}</p>
      </MetaDataContainer>
      </GridContainer>
      <Comments comments={movie.comments}/>
    </LargeMovieContainer>
  );
}
