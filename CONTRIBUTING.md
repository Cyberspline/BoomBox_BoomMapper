# BoomMapper Contributing Manual

Thanks for taking the time to contribute to BoomMapper.

This short manual will contain some useful information about creating the best contributions to ChroMapper. Before you begin, make sure to [read the BUILD guide](BUILD.md) to properly set up a dev environment.

# Good Bug Reports

A good bug report allows us to easily diagnose and solve the issue you are experiencing.

In BoomMapper, any errors and exceptions automatically open the Developer Console. You can toggle the Developer Console on and off with the `~` key.

Any bugs you should report are colored purple in the Developer Console, with a cyan flag icon appearing on the left. By clicking the flag, a bug report will be generated and uploaded to [paste.ee](https://paste.ee). This includes all of the relevant information we need to diagnose the issue. When the report is uploaded, BoomMapper will open the bug report in a new browser tab, allowing you to easily copy/paste the link.

## Reporting on Discord

You can report any bugs or issues in the `#bugs-editor` channel of the official BoomBox Discord. Please keep all editor-related bug reports in that channel.

Please be sure to include:
- BoomMapper version (found in the bottom right of the Options menu)
- A clear and concise description of the problem
- If applicable, the paste.ee link to your generated bug report
- Applicable screenshots or videos
- Steps to reproduce the problem (if available)

## Reporting on GitHub

You can also report issues on the GitHub. Ensure that you selected the `BoomMapper Bug Report` issue template, and filling out the information that is requested.

# Pull Requests

Contributions to BoomMapper are always welcome, but to keep the project codebase consistent, we'd ask that you follow some guidelines when making pull requests.

## Coding Convention / Styling Guidelines

BoomMapper comes with a `.editorconfig` file which outlines most of the convention and styling guidelines used by the project. We use this file to enforce code consistency, and a certain level of code quality as well. Furthermore, we recommend installing [Microsoft.Unity.Analyzers](https://github.com/microsoft/Microsoft.Unity.Analyzers) if you use Visual Studio, as that will also help in enforcing code quality when dealing with Unity.

When making pull requests, we ask that your PR **contains no errors or warnings from `.editorconfig` violations.** If not, a PR review will be sent asking to conform to the `.editorconfig` file, and your PR will not be merged until then.

### IDEs

The two main IDEs we use for BoomMapper development are Visual Studio and JetBrains Rider. These IDEs both support `.editorconfig` files, and will properly alert you to any violations.

If you use another IDE outside of Visual Studio or Rider, your mileage may vary.

## Cross-platform Compatibility

We ask that any and all changes to BoomMapper remain platform-agnostic to maintain BoomMapper's status as a cross-platform map editor.

If your pull request does contain platform-dependent code, we request that the code does not hinder BoomMapper's ability to run on other platforms.

Any pull requests that do not follow these cross-platform guidelines will not be merged.