import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Button } from '../../components/buttons';
import { Form } from '../../components/forms';
import { InputField } from '../../components/inputs';
import { FlexContainer } from './styles';
import { useFormik } from 'formik';
import { useCreateUserMutation } from '../../api/users';
import { showMessage, MessageTypes } from '../../components/toast';


export default function SignupPage() {
  const navigate = useNavigate();
  const [registerUser, { isLoading }] = useCreateUserMutation();

  const handleSignup = (values) => {
    const { name, username, passwordHash } = values;
    registerUser({ name, username, passwordHash })
    .unwrap()
    .then((result) => {
      if (result.status) {
        showMessage(MessageTypes.SUCCESS, 'Signup Successful. Please login.');
        navigate('/login');
      }else{
        showMessage(MessageTypes.ERROR, result.message);
      }
    });
    return;
  };

  const formHandler = useFormik({
    initialValues: {
      name: '',
      username: '',
      passwordHash: '',
    },
    onSubmit: handleSignup,
  });

  return (
    <FlexContainer>
      <Form onSubmit={formHandler.handleSubmit}>
        <h1>Signup</h1>
        <InputField label="Full Name" name="name" type="text" required onChange={formHandler.handleChange} value={formHandler.values.name}/>
        <InputField label="Username" name="username" type="text" required onChange={formHandler.handleChange} value={formHandler.values.username}/>
        <InputField label="Password" name="passwordHash" type="password" required onChange={formHandler.handleChange} value={formHandler.values.passwordHash}/>
        <Button type='submit' disabled={isLoading}> {isLoading ? 'Loading...' : 'Signup'}</Button>
        <Link to="/login">Already have an account? Login</Link>
      </Form>
    </FlexContainer>
  );
}
