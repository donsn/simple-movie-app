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
import { useAddCommentToMovieMutation } from '../../api/movies';
import { useFormik } from 'formik';
import { showMessage, MessageTypes } from '../../components/toast';

export default function SingleMoviePage() {
  const { slug } = useParams();
  const { data: movie, isLoading, refetch } = useGetMovieBySlugQuery(slug);
  const { authenticated } = useAuthentication();
  const [addComment, { isLoading: isCommentLoading }] = useAddCommentToMovieMutation();

  const handleComment = (values, action) => {
    addComment({ movieId: movie.id, comment: values })
      .unwrap()
      .then((res) => {
        if (res.status) {
          refetch();
          action.resetForm();
        }
        else {
          showMessage(MessageTypes.ERROR, res.message);
        }
      })
  }


  const formhandler = useFormik({
    initialValues: {
      name: '',
      content: '',
    },
    onSubmit: handleComment
  });


  if (isLoading) {
    return <FlexContainer>
      <HashLoader color='#4FB286'>Loading...</HashLoader>
    </FlexContainer>
  }

  return (
    <FlexContainer direction="column">
      <LargeMovieView movie={movie} />
      <div>

        {authenticated && (<Form onSubmit={formhandler.handleSubmit}>
          <h2>Add Comment</h2>
          <InputField name="name" label="Name" type="text" required onChange={formhandler.handleChange} value={formhandler.values.name} />
          <InputField name="content" label="Comment" type="text" required onChange={formhandler.handleChange} value={formhandler.values.content} />
          <Button type="submit" disabled={isCommentLoading}>{
            isCommentLoading ? 'Adding Comment...' : 'Add Comment'
          }</Button>
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
