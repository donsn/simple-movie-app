import React from 'react';
import LargeMovieView from '../../components/movie/large';
import { FlexContainer } from './styles';

export default function SingleMoviePage() {
  return (
    <FlexContainer>
      <LargeMovieView/>
    </FlexContainer>
  );
}
