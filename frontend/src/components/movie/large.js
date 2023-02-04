import React from 'react';
import { LargeMovieContainer, MovieDescriptionContainer, MovieDetailsContainer } from './styles';
import {useAuthentication} from '../../hooks/auth';
/**
 * Renders a large movie view
 * @returns {JSX.Element}
 */
export default function LargeMovieView({movie}) {
  const {authenticated } = useAuthentication();
  return (
    <LargeMovieContainer>
      <MovieDetailsContainer>
        <h1>Movie Title</h1>
        <img src="https://via.placeholder.com/500x600" alt="Movie Poster" />
        <h2>Description</h2>
        <MovieDescriptionContainer>
          <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed euismod
            nunc euismod, ultricies nisl sed, ultricies nisl. Sed euismod nunc
            euismod, ultricies nisl sed, ultricies nisl. Sed euismod nunc euismod,
            ultricies nisl sed, ultricies nisl. Sed euismod nunc euismod, ultricies
            nisl sed, ultricies nisl. Sed euismod nunc euismod, ultricies nisl sed,
            ultricies nisl. Sed euismod nunc euismod, ultricies nisl sed, ultricies
          </p>
        </MovieDescriptionContainer>
        <h2>Genre</h2>
        <p>Action, Adventure</p>
        <h2>Released</h2>
        <p>2020</p>
        <h2>Rating</h2>
        <p>5</p>
        <h2>Ticket Price</h2>
        <p>$10</p>
        <h2>Country</h2>
        <p>USA</p>
      </MovieDetailsContainer>
      <div>
        <h2>Comments</h2>
      </div>
      {authenticated && (
        <button type="button">Comment</button>
      )}
    </LargeMovieContainer>
  );
}
