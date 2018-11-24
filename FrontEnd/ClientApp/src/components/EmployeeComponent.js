import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/EmployeeReducer';

class EmployeeComponent extends Component {
  componentWillMount() {
    // This method runs when the component is first added to the page
      const startDateIndex = 0;
      this.props.requestWeatherForecasts(startDateIndex);
  }

  componentWillReceiveProps(nextProps) {
    // This method runs when incoming props (e.g., route params) change
    //const startDateIndex = parseInt(nextProps.match.params.startDateIndex, 10) || 0;     
   }

    onChange(event) {
        let index = event.target.value;
        this.props.changeEmployeeId(index);
    }

    onClick(event) {        
        this.props.requestWeatherForecasts();        
    }


  render() {
    return (
      <div>
        <h1>Search Employees</h1>
        <p>Please seach for a particular employee or all of them.</p>
            <input type="number" onChange={this.onChange.bind(this)} />
            <input type="button" onClick={this.onClick.bind(this)} value="Get Employees" />
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
        {props.forecasts.map(employee =>
            <tr key={employee.id}>
            <td>{employee.id}</td>
            <td>{employee.name}</td>
            <td>{employee.contractTypeName}</td>
            <td>{employee.roleName}</td>
            <td>{employee.roleDescription}</td>
            <td>{employee.annualSalary}</td>
          </tr>
        )}
      </tbody>
    </table>
  );
}


export default connect(
    state => state.employees,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(EmployeeComponent);
