import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/WeatherForecasts';

class FetchData extends Component {
  componentWillMount() {
    // This method runs when the component is first added to the page
      const startDateIndex = 0;
    this.props.requestWeatherForecasts(startDateIndex);
  }

  componentWillReceiveProps(nextProps) {
    // This method runs when incoming props (e.g., route params) change
    //const startDateIndex = parseInt(nextProps.match.params.startDateIndex, 10) || 0;
      const startDateIndex = 0;
    this.props.requestWeatherForecasts(startDateIndex);
  }

  render() {
    return (
      <div>
        <h1>Search Employees</h1>
        <p>Please seach for a particular employee or all of them.</p>
        <input type="number"/>
        <button type="button"> Get Employees</button>
        {renderForecastsTable(this.props)}
      </div>
    );
  }
}

function renderForecastsTable(props) {
  return (
    <table className='table'>
      <thead>
        <tr>
          <th>Id</th>
          <th>Name</th>
          <th>Contract Type Name</th>
          <th>Role Name</th>
            <th>Role Description</th>
            <th>Annual Salary</th>
        </tr>
      </thead>
      <tbody>
        {props.forecasts.map(forecast =>
            <tr key={forecast.id}>
            <td>{forecast.id}</td>
            <td>{forecast.name}</td>
            <td>{forecast.contractTypeName}</td>
            <td>{forecast.roleName}</td>
            <td>{forecast.roleDescription}</td>
            <td>{forecast.annualSalary}</td>
          </tr>
        )}
      </tbody>
    </table>
  );
}


export default connect(
  state => state.weatherForecasts,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(FetchData);
