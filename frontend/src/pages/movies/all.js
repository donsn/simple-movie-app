import React from 'react';
import SmallMovieView from '../../components/movie/small';
import { FlexContainer, Title } from './styles';

export default function MovieListPage() {
  return (
    <div>
      <Title>All Movies</Title>
      <FlexContainer>
        <SmallMovieView/>
        <SmallMovieView/>
        <SmallMovieView/>
        <SmallMovieView/>
        <SmallMovieView/>
        <SmallMovieView/>
      </FlexContainer>
    </div>
  );
}
