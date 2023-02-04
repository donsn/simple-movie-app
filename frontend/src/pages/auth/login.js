import React from 'react';
import { Button } from '../../components/buttons';
import { Form } from '../../components/forms';
import { InputField } from '../../components/inputs';
import { FlexContainer } from './styles';

export default function LoginPage() {
  return (
    <FlexContainer>
      <Form>
        <h1>Login</h1>
        <InputField label="Username" name="username" type="text" />
        <InputField label="Password" name="password" type="password" />
        <Button> Login</Button>
      </Form>
  </FlexContainer>
  );
}
