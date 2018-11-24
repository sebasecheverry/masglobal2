import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import EmployeeComponent from './components/EmployeeComponent';

export default () => (
  <Layout>
        <Route exact path='/' component={EmployeeComponent} />   
  </Layout>
);
