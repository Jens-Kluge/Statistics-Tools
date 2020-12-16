# Statistics-Tools
Statistics Tools as standalone windows executable.
Provides statistical analysis as windows standalone executable without the "help" of excel.

Currently implemented:
- import of a csv File

The column headers can be in the first row or in a separate csv file.
The rows should contain only numerical values, category labels are not yet supported.
- export of data to a new excel workbook
- selecting a data column and plotting the values as a histogram
- overlaying a fitted Weibull distribution over the histogram

The import/export as well as the plot can handle large amounts of data with 32000 rows and more and is still reasonably fast

The project uses the following packages: 
- oxyplot library for the plot
- mathnet.numeric for invoking the special functions needed to calculate the probability distributions

## Histogram Plot
![image](https://github.com/Jens-Kluge/Statistics-Tools/blob/master/Capture%20Statistic%20Tools.GIF)

## Box and Whiskas plot
![image](https://github.com/Jens-Kluge/Statistics-Tools/blob/e00bc0c1651f93befaf7b624c1133d63d79743e0/bw%20plot.GIF)
