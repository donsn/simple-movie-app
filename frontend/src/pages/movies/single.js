import React from 'react';
import { HashLoader } from 'react-spinners';
import { Link, useParams } from 'react-router-dom';
import LargeMovieView from '../../components/movie/large';
import { FlexContainer } from './styles';
import { useGetMovieBySlugQuery } from '../../api/movies';
import { Form } from '../../components/forms';
import { InputField } from '../../components/inputs';
import { Button } from '../../components/buttons';
import { useAuthentication } from '../../hooks/auth';

export default function SingleMoviePage() {
  const { slug } = useParams();
  const { data: movie, isLoading } = useGetMovieBySlugQuery(slug);
  const { authenticated } = useAuthentication();

  if (isLoading) {
    return <FlexContainer>
      <HashLoader color='#4FB286'>Loading...</HashLoader>
    </FlexContainer>
  }

  return (
    <FlexContainer direction="column">
      <LargeMovieView movie={movie} />
      <div>

        {authenticated && (<Form>
          <h2>Add Comment</h2>
          <InputField name="name" label="Name" type="text" required />
          <InputField name="comment" label="Comment" type="text" required />
          <Button type="submit">Submit</Button>
        </Form>)}

        {!authenticated &&
          (<Form>
            <Link to="/login">Login</Link> to add a comment
          </Form>
          )}

      </div>
    </FlexContainer>
  );
}
