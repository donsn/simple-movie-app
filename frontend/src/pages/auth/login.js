import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Button } from '../../components/buttons';
import { Form } from '../../components/forms';
import { InputField } from '../../components/inputs';
import { FlexContainer } from './styles';
import { useFormik } from 'formik';
import { useLoginUserMutation } from '../../api/users';
import { showMessage, MessageTypes } from '../../components/toast';
import { saveContent } from '../../utilities/storage';

export default function LoginPage() {
  const navigate = useNavigate();

  const [loginUser, { isLoading }] = useLoginUserMutation();

  const handleLogin = (values) => {
    const { username, passwordHash } = values;
    loginUser({ username, password: passwordHash })
    .unwrap()
    .then((result) => {
      if (result.succeeded) {
        saveContent('x-token', result.data.token);
        showMessage(MessageTypes.SUCCESS, 'Login Successful');
        navigate('/movies');
      }else{
        showMessage(MessageTypes.ERROR, result.message);
      }
    });
    return;
  };

  const formHandler = useFormik({
    initialValues: {
      username: '',
      passwordHash: '',
    },
    onSubmit: handleLogin,
  });


  return (
    <FlexContainer>
      <Form onSubmit={formHandler.handleSubmit}>
        <h1>Login</h1>
        <InputField required label="Username" name="username" type="text" onChange={formHandler.handleChange}  value={formHandler.values.username}/>
        <InputField required label="Password" name="passwordHash" type="password"  onChange={formHandler.handleChange}  value={formHandler.values.passwordHash}/>
        <Button disabled={isLoading} type='submit'> 
          {
          isLoading ? 'Loading...' : 'Login'
          }
          </Button>
        <Link to="/register">Don't have an account? Signup</Link>
      </Form>
    </FlexContainer>
  );
}
